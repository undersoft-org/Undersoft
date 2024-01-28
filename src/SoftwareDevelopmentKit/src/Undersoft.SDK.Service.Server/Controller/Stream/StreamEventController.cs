﻿using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Text.Json;

namespace Undersoft.SDK.Service.Server.Controller.Stream;

using Operation.Command;
using Operation.Query;

using Undersoft.SDK.Service.Server.Operation.Remote;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Data.Query;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Data.Response;

[StreamData]
public abstract class StreamEventController<TKey, TStore, TEntity, TDto> : ControllerBase, IStreamDataController<TDto> where TDto : class, IOrigin, IInnerProxy
    where TEntity : class, IOrigin, IInnerProxy
    where TStore : IDataServerStore
{
    protected Func<TKey, Func<TDto, object>> _keysetter = k => e => e.SetId(k);
    protected Func<TKey, Expression<Func<TEntity, bool>>> _keymatcher;
    protected Func<TDto, Expression<Func<TEntity, bool>>> _predicate;
    protected readonly IServicer _servicer;
    protected readonly EventPublishMode _publishMode;

    public StreamEventController() : this(new Servicer(), null, k => e => e.SetId(k), null, EventPublishMode.PropagateCommand) { }

    public StreamEventController(IServicer servicer,
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
        return _servicer.CreateStream(new GetAsync<TStore, TEntity, TDto>(0, 0));
    }

    public virtual Task<ResultString> Count()
    {
        return Task.FromResult(new ResultString(_servicer.use<TStore, TEntity>().Count().ToString()));
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
                    new FilterAsync<TStore, TEntity, TDto>(0, 0,
                        new FilterExpression<TEntity>(query.FilterItems).Create(),
                        new SortExpression<TEntity>(query.SortItems)
                    )
                );
    }

    public virtual IAsyncEnumerable<ResultString> Creates([FromBody] TDto[] dtos)
    {
        var result = _servicer.CreateStream(new CreateSetAsync<TStore, TEntity, TDto>
                                                    (_publishMode, dtos));

        var response = result.ForEachAsync(c => new ResultString(c.IsValid
                                             ? c.Id.ToString()
                                             : c.ErrorMessages));
        return response;
    }

    public virtual IAsyncEnumerable<ResultString> Changes([FromBody] TDto[] dtos)
    {
        var result = _servicer.CreateStream(new ChangeSetAsync<TStore, TEntity, TDto>
                                                   (_publishMode, dtos));

        var response = result.ForEachAsync(c => new ResultString(c.IsValid
                                              ? c.Id.ToString()
                                              : c.ErrorMessages));
        return response;
    }

    public virtual IAsyncEnumerable<ResultString> Updates([FromBody] TDto[] dtos)
    {
        var result = _servicer.CreateStream(new UpdateSetAsync<TStore, TEntity, TDto>
                                                 (_publishMode, dtos));

        var response = result.ForEachAsync(c => new ResultString(c.IsValid
                                               ? c.Id.ToString()
                                               : c.ErrorMessages));
        return response;
    }

    public virtual IAsyncEnumerable<ResultString> Deletes([FromBody] TDto[] dtos)
    {
        var result = _servicer.CreateStream(new DeleteSetAsync<TStore, TEntity, TDto>
                                                  (_publishMode, dtos));

        var response = result.ForEachAsync(c => new ResultString(c.IsValid
                                               ? c.Id.ToString()
                                               : c.ErrorMessages));
        return response;
    }
}
