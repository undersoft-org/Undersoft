using System.Linq.Expressions;
using System.Text.Json;

namespace Undersoft.SDK.Service.Server.Controller.Stream;

using Operation.Command;
using Operation.Query;
using Undersoft.SDK.Service.Client;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Query;
using Undersoft.SDK.Service.Infrastructure.Store;

[StreamData]
public abstract class StreamDataController<TKey, TEntry, TReport, TEntity, TDto> : IStreamDataController<TDto>
    where TDto : class, IDataObject
    where TEntity : class, IDataObject
    where TEntry : IDataServerStore
    where TReport : IDataServerStore
{
    protected Func<TKey, Func<TDto, object>> _keysetter = k => e => e.SetId(k);
    protected Func<TKey, Expression<Func<TEntity, bool>>> _keymatcher;
    protected Func<TDto, Expression<Func<TEntity, bool>>> _predicate;
    protected readonly IServicer _servicer;
    protected readonly EventPublishMode _publishMode;

    public StreamDataController() : this(new Servicer(), null, k => e => e.SetId(k), null, EventPublishMode.PropagateCommand) { }

    public StreamDataController(IServicer servicer,
        Func<TDto, Expression<Func<TEntity, bool>>> predicate,
        Func<TKey, Func<TDto, object>> keysetter,
        Func<TKey, Expression<Func<TEntity, bool>>> keymatcher,
        EventPublishMode publishMode = EventPublishMode.PropagateCommand
    )
    {
        _keymatcher = keymatcher;
        _keysetter = keysetter;
        _servicer = servicer;
        _publishMode = publishMode;
    }

    public virtual IAsyncEnumerable<TDto> All()
    {
        return _servicer.CreateStream(new GetAsync<TReport, TEntity, TDto>(0, 0));
    }

    public virtual Task<string> Count()
    {
        return Task.FromResult(_servicer.use<TReport, TEntity>().Count().ToString());
    }

    public virtual IAsyncEnumerable<TDto> Query(QuerySet query)
    {
        query.FilterItems.ForEach(
            (fi) =>
                fi.Value = JsonSerializer.Deserialize(
                    ((JsonElement)fi.Value).GetRawText(),
                    Type.GetType($"System.{fi.Type}", null, null, false, true)
                )
        );

        return
            _servicer
                .CreateStream(
                    new FilterAsync<TReport, TEntity, TDto>(0, 0,
                        new FilterExpression<TEntity>(query.FilterItems).Create(),
                        new SortExpression<TEntity>(query.SortItems)
                    )
                );
    }

    public virtual IAsyncEnumerable<string> Creates(TDto[] dtos)
    {
        var result = _servicer.CreateStream(new CreateSetAsync<TEntry, TEntity, TDto>
                                                    (_publishMode, dtos));

        var response = result.ForEachAsync(c => c.IsValid
                                               ? c.Id.ToString()
                                               : c.ErrorMessages);
        return response;
    }

    public virtual IAsyncEnumerable<string> Changes(TDto[] dtos)
    {
        var result = _servicer.CreateStream(new ChangeSetAsync<TEntry, TEntity, TDto>
                                                   (_publishMode, dtos));

        var response = result.ForEachAsync(c => c.IsValid
                                              ? c.Id.ToString()
                                              : c.ErrorMessages);
        return response;
    }

    public virtual IAsyncEnumerable<string> Updates(TDto[] dtos)
    {
        var result = _servicer.CreateStream(new UpdateSetAsync<TEntry, TEntity, TDto>
                                                 (_publishMode, dtos));

        var response = result.ForEachAsync(c => c.IsValid
                                             ? c.Id.ToString()
                                             : c.ErrorMessages);
        return response;
    }

    public virtual IAsyncEnumerable<string> Deletes(TDto[] dtos)
    {
        var result = _servicer.CreateStream(new DeleteSetAsync<TEntry, TEntity, TDto>
                                                  (_publishMode, dtos));

        var response = result.ForEachAsync(c => c.IsValid
                                             ? c.Id.ToString()
                                             : c.ErrorMessages);
        return response;
    }
}
