﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Undersoft.SDK.Service.Server.Controller.Open;

using FluentValidation.Results;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;
using Microsoft.OData.Edm;
using Operation.Command;
using System.Runtime.Serialization;
using System.Text.Json;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Operation.Invocation;

[OpenService]
[ODataAttributeRouting]
[Route(StoreRoutes.OpenServiceRoute)]
public abstract class OpenServiceController<TStore, TService, TModel>
    : ODataController,
        IOpenServiceController<TStore, TService, TModel>
    where TModel : class, new()
    where TService : class
    where TStore : IDataServerStore
{
    protected readonly IServicer _servicer;

    protected OpenServiceController() { }

    public OpenServiceController(IServicer servicer)
    {
        _servicer = servicer;
    }

    [HttpGet("{method}")]
    public virtual async Task<IActionResult> Get(
        [FromRoute] string method,
        [FromRoute] ODataParameterValue parameter
    )
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _servicer.Send(
            new Function<TStore, TService, TModel>(
                method,
                new Arguments(new Argument(parameter.EdmType.ShortQualifiedName(), parameter.Value))
            )
        );

        return !result.IsValid ? BadRequest(result.ErrorMessages) : Ok(result.Response);
    }

    [HttpPost("{method}")]
    public virtual async Task<IActionResult> Post(
        [FromRoute] string method,
        [FromBody] ODataActionParameters arguments
    )
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _servicer.Send(
            new Action<TStore, TService, TModel>(method, (Dictionary<string, object>)arguments)
        );

        return (!result.IsValid ? BadRequest(result.ErrorMessages) : Ok(result.Response));
    }
}
