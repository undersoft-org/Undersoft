using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System.Linq.Expressions;

namespace Undersoft.SDK.Service.Server.Controller.Open;

using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Operation.Command;
using Operation.Query;
using System.Text.Json;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Uniques;

//[IgnoreApi]
[OpenData]
[ODataAttributeRouting]
public abstract class OpenCqrsController<TKey, TEntry, TReport, TEntity, TDto>
    : OpenDataController<TKey, TEntry, TEntity, TDto>
    where TDto : class, IDataObject
    where TEntity : class, IDataObject
    where TEntry : IDataServerStore
    where TReport : IDataServerStore
{
    protected OpenCqrsController() { }

    protected OpenCqrsController(
        IServicer servicer,
        EventPublishMode publishMode = EventPublishMode.PropagateCommand
    ) : this(servicer, null, k => e => e.SetId(k), k => e => k.Equals(e.Id), publishMode) { }

    protected OpenCqrsController(
        IServicer servicer,
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

    [EnableQuery]
    public override async Task<IQueryable<TDto>> Get()
    {
        return await _servicer.Send(new GetQuery<TReport, TEntity, TDto>());
    }

    [EnableQuery]
    public override async Task<UniqueOne<TDto>> Get([FromRoute] TKey key)
    {
        return new UniqueOne<TDto>(
            await _servicer.Send(new FindQuery<TReport, TEntity, TDto>(_keymatcher(key)))
        );
    }

    public override async Task<IActionResult> Post([FromBody] TDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _servicer.Send(new Create<TEntry, TEntity, TDto>(_publishMode, dto));

        return !result.IsValid
            ? UnprocessableEntity(result.ErrorMessages.ToArray())
            : Created(result.Id as object);
    }

    public override async Task<IActionResult> Patch([FromRoute] TKey key, [FromBody] TDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _keysetter(key).Invoke(dto);

        var result = await _servicer.Send(
            new Change<TEntry, TEntity, TDto>(_publishMode, dto, _predicate)
        );

        return !result.IsValid
            ? UnprocessableEntity(result.ErrorMessages.ToArray())
            : Updated(result.Id as object);
    }

    public override async Task<IActionResult> Put([FromRoute] TKey key, [FromBody] TDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _keysetter(key).Invoke(dto);

        var result = await _servicer.Send(
            new Update<TEntry, TEntity, TDto>(_publishMode, dto, _predicate)
        );

        return !result.IsValid
            ? UnprocessableEntity(result.ErrorMessages.ToArray())
            : Updated(result.Id as object);
    }

    public override async Task<IActionResult> Delete([FromRoute] TKey key)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _servicer.Send(new Delete<TEntry, TEntity, TDto>(_publishMode, key));

        return !result.IsValid
            ? UnprocessableEntity(result.ErrorMessages.ToArray())
            : Ok(result.Id as object);
    }
}
