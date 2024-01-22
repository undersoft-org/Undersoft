using Microsoft.AspNetCore.Mvc;

namespace Undersoft.SDK.Service.Server.Controller.Crud;
using Operation.Remote.Command;
using Undersoft.SDK;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Server.Operation.Command;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Client.Remote;
using Undersoft.SDK.Service.Server.Operation.Invocation;
using System.Text.Json;

[ApiController]
[RemoteCrudDataActionService]
[Route($"{StoreRoutes.CrudAuthRoute}/[controller]")]
public abstract class ApiServiceRemoteController<TStore, TService, TModel>
    : ControllerBase,
        IApiServiceRemoteController<TStore, TService, TModel>
    where TModel : class, IOrigin
    where TService : class
    where TStore : IDataServiceStore
{    
    protected readonly IServicer _servicer;    

    protected ApiServiceRemoteController() { }

    protected ApiServiceRemoteController(
        IServicer servicer
    )
    {
        _servicer = servicer;            
    }

    [HttpPost("{method}")]
    public virtual async Task<IActionResult> Post([FromRoute] string method, [FromBody] Dictionary<string, JsonElement> dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
                                   
            var result = await _servicer.Send(
                new RemoteInvoke<TStore, TService, TModel>(method)
            );

            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Ok(result.Response);
    }

    [HttpGet("{method}")]
    public virtual async Task<IActionResult> Get([FromRoute] string method)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

            var result = await _servicer.Send(
                new RemoteInvoke<TStore, TService, TModel>(method)
            );

            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Ok(result.Response);

    }
}
