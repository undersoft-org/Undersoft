﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Undersoft.SDK.Service.Server.Controller.Open;

using Microsoft.AspNetCore.OData.Formatter;
using Operation.Command;
using System.Text.Json;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Operation.Remote.Command;

[RemoteOpenDataActionService]
public abstract class OpenDataActionRemoteController<TStore, TKind, TDto, TModel>
    : ODataController, IOpenDataActionRemoteController<TStore, TKind, TDto, TModel>
    where TModel : class, IOrigin
    where TDto : class, IOrigin
    where TKind : struct, Enum
    where TStore : IDataServiceStore
{
    protected readonly IServicer _servicer;

    protected OpenDataActionRemoteController() { }

    public OpenDataActionRemoteController(
        IServicer servicer
    )
    {
        _servicer = servicer;      
    }

    [HttpPost(StoreRoutes.OpenDataRoute+"/[controller]/{kind}")]
    public virtual async Task<IActionResult> Post([FromRoute] string kind, [FromBody] ODataActionParameters parameters)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (Enum.TryParse(kind, out TKind method))
        {
            var result = await _servicer.Send(
                new RemoteExecute<TStore, TDto, TModel, TKind>(method, ((JsonElement)parameters[typeof(TModel).Name]).Deserialize<TModel>(), CommandMode.Action)
            );

            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Ok(result.Response);
        }
        return NotFound(kind);
    }

    [HttpGet(StoreRoutes.OpenDataRoute+"/[controller]/{kind}")]
    public virtual async Task<IActionResult> Get([FromRoute] string kind)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (Enum.TryParse(kind, out TKind method))
        {
            var result = await _servicer.Send(
                new RemoteExecute<TStore, TDto, TModel, TKind>(method, null, CommandMode.Function)
            );

            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Ok(result.Response);
        }
        return NotFound(kind);
    }
}
