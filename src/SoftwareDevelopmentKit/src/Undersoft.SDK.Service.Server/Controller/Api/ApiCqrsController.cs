﻿using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Text.Json;

namespace Undersoft.SDK.Service.Server.Controller.Api;

using Operation.Command;
using Operation.Query;
using Undersoft.SDK.Service.Data.Client.Attributes;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Data.Query;
using Undersoft.SDK.Service.Data.Store;

[ApiController]
[ApiData]
[Route($"{StoreRoutes.ApiDataRoute}/[controller]")]
public class ApiCqrsController<TKey, TEntry, TReport, TEntity, TDto, TService>
    : ApiDataController<TKey, TEntry, TEntity, TDto, TService>
    where TDto : class, IOrigin, IInnerProxy
    where TEntity : class, IOrigin, IInnerProxy
    where TEntry : IDataServerStore
    where TReport : IDataServerStore
    where TService : class
{
    protected ApiCqrsController() { }

    protected ApiCqrsController(
        IServicer servicer,
        EventPublishMode publishMode = EventPublishMode.PropagateCommand
    ) : this(servicer, null, k => e => e.SetId(k), null, publishMode) { }

    protected ApiCqrsController(
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

    [HttpGet]
    public override async Task<IActionResult> Get([FromHeader] int page, [FromHeader] int limit)
    {
        return Ok(
            await _servicer
                .Report(new Get<TReport, TEntity, TDto>((page - 1) * limit, limit))
                .ConfigureAwait(true)
        );
    }

    [HttpGet("count")]
    public override async Task<IActionResult> Count()
    {
        return Ok(await Task.Run(() => _servicer.use<TReport, TEntity>().Count()));
    }

    [HttpGet("{key}")]
    public override async Task<IActionResult> Get([FromRoute] TKey key)
    {
        return Ok(
            _keymatcher == null
                ? await _servicer.Entry(new Find<TReport, TEntity, TDto>(key)).ConfigureAwait(false)
                : await _servicer
                    .Report(new Find<TReport, TEntity, TDto>(_keymatcher(key)))
                    .ConfigureAwait(false)
        );
    }

    [HttpPost("query")]
    public override async Task<IActionResult> Post([FromBody] QuerySet query)
    {
        query.FilterItems.ForEach(
            (fi) =>
                fi.Value = JsonSerializer.Deserialize(
                    ((JsonElement)fi.Value).GetRawText(),
                    Type.GetType($"System.{fi.Type}", null, null, false, true)
                )
        );

        return Ok(
            await _servicer
                .Report(
                    new Filter<TReport, TEntity, TDto>(
                        0,
                        0,
                        new FilterExpression<TEntity>(query.FilterItems).Create(),
                        new SortExpression<TEntity>(query.SortItems)
                    )
                )
                .ConfigureAwait(false)
        );
    }

    [HttpPost]
    public override async Task<IActionResult> Post([FromBody] TDto[] dtos)
    {
        return (!ModelState.IsValid)
            ? BadRequest(ModelState)
            : await ExecuteSet(new ChangeSet<TEntry, TEntity, TDto>(_publishMode, dtos));
    }

    [HttpPost("{key}")]
    public override async Task<IActionResult> Post([FromRoute] TKey key, [FromBody] TDto dto)
    {
        _keysetter(key).Invoke(dto);

        return (!ModelState.IsValid)
            ? BadRequest(ModelState)
            : await Execute(new Create<TEntry, TEntity, TDto>(_publishMode, dto));
    }

    [HttpPatch]
    public override async Task<IActionResult> Patch([FromBody] TDto[] dtos)
    {
        return (!ModelState.IsValid)
            ? BadRequest(ModelState)
            : await ExecuteSet(
                new ChangeSet<TEntry, TEntity, TDto>(_publishMode, dtos, _predicate)
            );
    }

    [HttpPatch("{key}")]
    public override async Task<IActionResult> Patch([FromRoute] TKey key, [FromBody] TDto dto)
    {
        _keysetter(key).Invoke(dto);

        return (!ModelState.IsValid)
            ? BadRequest(ModelState)
            : await Execute(new Change<TEntry, TEntity, TDto>(_publishMode, dto, _predicate));
    }

    [HttpPut]
    public override async Task<IActionResult> Put([FromBody] TDto[] dtos)
    {
        return (!ModelState.IsValid)
            ? BadRequest(ModelState)
            : await ExecuteSet(
                new UpdateSet<TEntry, TEntity, TDto>(_publishMode, dtos, _predicate)
            );
    }

    [HttpPut("{key}")]
    public override async Task<IActionResult> Put([FromRoute] TKey key, [FromBody] TDto dto)
    {
        _keysetter(key).Invoke(dto);

        return (!ModelState.IsValid)
            ? BadRequest(ModelState)
            : await Execute(new Update<TEntry, TEntity, TDto>(_publishMode, dto, _predicate));
    }

    [HttpDelete]
    public override async Task<IActionResult> Delete([FromBody] TDto[] dtos)
    {
        return (!ModelState.IsValid)
            ? BadRequest(ModelState)
            : await ExecuteSet(new DeleteSet<TEntry, TEntity, TDto>(_publishMode, dtos));
    }

    [HttpDelete("{key}")]
    public override async Task<IActionResult> Delete([FromRoute] TKey key, [FromBody] TDto dto)
    {
        _keysetter(key).Invoke(dto);

        return (!ModelState.IsValid)
            ? BadRequest(ModelState)
            : await Execute(new Delete<TEntry, TEntity, TDto>(_publishMode, dto));
    }
}
