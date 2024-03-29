﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System.Linq.Expressions;

namespace Undersoft.SDK.Service.Server.Controller.Open;

using Operation.Remote.Command;
using Operation.Remote.Query;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Service.Data.Client.Attributes;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Data.Store;

[OpenDataRemote]
public abstract class OpenDataRemoteController<TKey, TStore, TDto, TModel, TService>
    : OpenServiceRemoteController<TStore, TService, TDto>,
        IOpenDataRemoteController<TKey, TDto, TModel>
    where TModel : class, IOrigin, IInnerProxy
    where TDto : class, IOrigin, IInnerProxy
    where TStore : IDataServiceStore
    where TService : class
{
    protected Func<TKey, Func<TModel, object>> _keysetter = k => e => e.SetId(k);
    protected Func<TKey, Expression<Func<TDto, bool>>> _keymatcher = k => e => k.Equals(e.Id);
    protected Func<TModel, Expression<Func<TDto, bool>>> _predicate;
    protected readonly EventPublishMode _publishMode = EventPublishMode.PropagateCommand;

    protected OpenDataRemoteController() { }

    protected OpenDataRemoteController(
        IServicer servicer,
        EventPublishMode publishMode = EventPublishMode.PropagateCommand
    ) : this(servicer, null, k => e => e.SetId(k), k => e => k.Equals(e.Id), publishMode) { }

    protected OpenDataRemoteController(
        IServicer servicer,
        Func<TModel, Expression<Func<TDto, bool>>> predicate,
        EventPublishMode publishMode = EventPublishMode.PropagateCommand
    ) : this(servicer, predicate, k => e => e.SetId(k), k => e => k.Equals(e.Id), publishMode) { }

    protected OpenDataRemoteController(
        IServicer servicer,
        Func<TModel, Expression<Func<TDto, bool>>> predicate,
        Func<TKey, Func<TModel, object>> keysetter,
        Func<TKey, Expression<Func<TDto, bool>>> keymatcher,
        EventPublishMode publishMode = EventPublishMode.PropagateCommand
    ) : base(servicer)
    {
        _keymatcher = keymatcher;
        _keysetter = keysetter;
        _publishMode = publishMode;
    }

    [EnableQuery]
    public virtual IQueryable<TModel> Get()
    {
        return _servicer.Report(new RemoteGetQuery<TStore, TDto, TModel>()).Result;
    }

    [EnableQuery]
    public virtual async Task<UniqueOne<TModel>> Get([FromRoute] TKey key)
    {
        return new UniqueOne<TModel>(
            await _servicer.Report(new RemoteFindQuery<TStore, TDto, TModel>(_keymatcher(key)))
        );
    }

    public virtual async Task<IActionResult> Post([FromBody] TModel dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _servicer.Send(
            new RemoteCreate<TStore, TDto, TModel>(_publishMode, dto)
        );

        return !result.IsValid
            ? UnprocessableEntity(result.ErrorMessages)
            : Created(result.Contract);
    }

    public virtual async Task<IActionResult> Patch([FromRoute] TKey key, [FromBody] TModel dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _keysetter(key).Invoke(dto);

        var result = await _servicer.Send(
            new RemoteChange<TStore, TDto, TModel>(_publishMode, dto, _predicate)
        );

        return !result.IsValid
            ? UnprocessableEntity(result.ErrorMessages)
            : Updated(result.Id as object);
    }

    public virtual async Task<IActionResult> Put([FromRoute] TKey key, [FromBody] TModel dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _keysetter(key).Invoke(dto);

        var result = await _servicer.Send(
            new RemoteUpdate<TStore, TDto, TModel>(_publishMode, dto, _predicate)
        );

        return !result.IsValid
            ? UnprocessableEntity(result.ErrorMessages)
            : Updated(result.Id as object);
    }

    public virtual async Task<IActionResult> Delete([FromRoute] TKey key)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _servicer.Send(
            new RemoteDelete<TStore, TDto, TModel>(_publishMode, key)
        );

        return !result.IsValid
            ? UnprocessableEntity(result.ErrorMessages)
            : Updated(result.Id as object);
    }
}
