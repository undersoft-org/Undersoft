using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System.Linq.Expressions;

namespace Undersoft.SDK.Service.Server.Controller.Open;

using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Operation.Command;
using Operation.Query;
using System.Text.Json;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Documentation;
using Undersoft.SDK.Uniques;

[OpenData]
public abstract class OpenDataController<TKey, TStore, TEntity, TDto, TService>
    : OpenServiceController<TStore, TService, TDto>, IOpenDataController<TKey, TEntity, TDto>
    where TDto : class, IDataObject, new()
    where TEntity : class, IDataObject
    where TStore : IDataServerStore
    where TService : class
{
    protected Func<TKey, Func<TDto, object>> _keysetter = k => e => e.SetId(k);
    protected Func<TKey, Expression<Func<TEntity, bool>>> _keymatcher = k => e => k.Equals(e.Id);
    protected Func<TDto, Expression<Func<TEntity, bool>>> _predicate;
    protected EventPublishMode _publishMode;

    public OpenDataController() { }

    public OpenDataController(IServicer servicer) : base(servicer) { }

    protected OpenDataController(
        IServicer servicer,
        EventPublishMode publishMode = EventPublishMode.PropagateCommand
    ) : this(servicer, null, k => e => e.SetId(k), k => e => k.Equals(e.Id), publishMode) { }

    protected OpenDataController(
        IServicer servicer,
        Func<TDto, Expression<Func<TEntity, bool>>> predicate,
        Func<TKey, Func<TDto, object>> keysetter,
        Func<TKey, Expression<Func<TEntity, bool>>> keymatcher,
        EventPublishMode publishMode = EventPublishMode.PropagateCommand
    ) : base(servicer)
    {
        _keymatcher = keymatcher;
        _keysetter = keysetter;
        _publishMode = publishMode;
    }

    public virtual Func<IRepository<TEntity>, IQueryable<TEntity>> Transformations { get; set; }

    [EnableQuery]
    public virtual async Task<IQueryable<TDto>> Get()
    {
        return await _servicer.Send(new GetQuery<TStore, TEntity, TDto>(Transformations));
    }

    [EnableQuery]
    public virtual async Task<UniqueOne<TDto>> Get([FromRoute] TKey key)
    {
        return new UniqueOne<TDto>(await _servicer.Send(new FindQuery<TStore, TEntity, TDto>(_keymatcher(key)) { Processings = Transformations }));
    }

    public virtual async Task<IActionResult> Post(TDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _servicer
            .Execute(new Create<TStore, TEntity, TDto>(_publishMode, dto) { Processings = Transformations });

        return !result.IsValid ? UnprocessableEntity(result.ErrorMessages.ToArray()) : Created(result.Id as object);
    }

    public virtual async Task<IActionResult> Patch([FromRoute] TKey key, [FromBody] TDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _keysetter(key).Invoke(dto);

        var result = await _servicer
            .Execute(new Change<TStore, TEntity, TDto>(_publishMode, dto, _predicate) { Processings = Transformations });

        return !result.IsValid ? UnprocessableEntity(result.ErrorMessages.ToArray()) : Updated(result.Id as object);
    }

    public virtual async Task<IActionResult> Put([FromRoute] TKey key, [FromBody] TDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _keysetter(key).Invoke(dto);

        var result = await _servicer
            .Execute(new Update<TStore, TEntity, TDto>(_publishMode, dto, _predicate) { Processings = Transformations });

        return !result.IsValid ? UnprocessableEntity(result.ErrorMessages.ToArray()) : Updated(result.Id as object);
    }

    public virtual async Task<IActionResult> Delete([FromRoute] TKey key)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _servicer
            .Execute(new Delete<TStore, TEntity, TDto>(_publishMode, key) { Processings = Transformations });

        return !result.IsValid ? UnprocessableEntity(result.ErrorMessages.ToArray()) : Ok(result.Id as object);
    }  
}
