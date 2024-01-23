using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Undersoft.SDK.Service.Server.Controller.Open;

using FluentValidation.Results;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.OData.Edm;
using Operation.Command;
using System.Text.Json;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Operation.Invocation;
using Undersoft.SDK.Service.Server.Operation.Remote.Command;
using Undersoft.SDK.Service.Server.Operation.Remote.Invocation;

[OpenServiceRemote]
public abstract class OpenServiceRemoteController<TStore, TService, TDto>
    : ODataController,
        IOpenDataActionRemoteController<TStore, TService, TDto>
    where TService : class
    where TDto : class
    where TStore : IDataServiceStore
{
    protected readonly IServicer _servicer;

    protected OpenServiceRemoteController() { }

    public OpenServiceRemoteController(IServicer servicer)
    {
        _servicer = servicer;
    }

    [HttpGet]
    [ODataRouteComponent("Function(Method={name})")]
    public virtual async Task<IActionResult> Function(
        [FromODataUri] string name
    )
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _servicer.Send(
            new RemoteFunction<TStore, TService, TDto>(name));

        return !result.IsValid ? BadRequest(result.ErrorMessages) : Ok(result.Response);
    }

    [HttpPost]
    [ODataRouteComponent("Action(Method={name})")]
    public virtual async Task<IActionResult> Action(
        [FromODataUri] string name,
        [FromBody] ODataActionParameters parameters
    )
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _servicer.Send(
            new RemoteAction<TStore, TService, TDto>(name, (Dictionary<string, object>)parameters)
        );

        return (!result.IsValid ? BadRequest(result.ErrorMessages) : Ok(result.Response));
    }
}
