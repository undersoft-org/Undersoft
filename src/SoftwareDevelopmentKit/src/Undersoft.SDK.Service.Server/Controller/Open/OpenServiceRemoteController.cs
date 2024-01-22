using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Undersoft.SDK.Service.Server.Controller.Open;

using FluentValidation.Results;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Operation.Command;
using System.Text.Json;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Operation.Invocation;
using Undersoft.SDK.Service.Server.Operation.Remote.Command;

[OpenServiceRemote]
[ODataAttributeRouting]
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

    [HttpGet("{method}")]
    public virtual async Task<IActionResult> Get(
       [FromRoute] string method,
       [FromHeader] string argument
   )
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _servicer.Send(new RemoteInvoke<TStore, TService, TDto>((object)argument, method));

        return !result.IsValid ? BadRequest(result.ErrorMessages) : Ok(result.Response);
    }

    [HttpPost("{method}")]
    public virtual async Task<IActionResult> Post(
        [FromRoute] string method,
        [FromBody] ODataActionParameters parameters
    )
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _servicer.Send(
            new RemoteInvoke<TStore, TService, TDto>(method, (Dictionary<string, object>)parameters)
        );

        return (!result.IsValid ? BadRequest(result.ErrorMessages) : Ok(result.Response));
    }
}
