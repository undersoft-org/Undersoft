using Microsoft.AspNetCore.Mvc;

namespace Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Operation.Invocation;

[ApiServiceRemote]
public abstract class ApiServiceController<TStore, TService, TModel>
    : ControllerBase,
        IApiServiceRemoteController<TStore, TService, TModel>
    where TModel : class, IOrigin
    where TService : class
    where TStore : IDataServerStore
{    
    protected readonly IServicer _servicer;    

    protected ApiServiceController() { }

    protected ApiServiceController(
        IServicer servicer
    )
    {
        _servicer = servicer;            
    }

    [HttpPost("{method}")]
    public virtual async Task<IActionResult> Post([FromRoute] string method, [FromBody] Dictionary<string, object> dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
                                   
            var result = await _servicer.Send(
                new Action<TStore, TService, TModel>(method, new Arguments(dto))
            );

            return !result.IsValid
                ? BadRequest(result.ErrorMessages)
                : Ok(result.Response);
    }

    [HttpGet("{method}")]
    public virtual async Task<IActionResult> Get([FromRoute] string method)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

            var result = await _servicer.Send(
                new Function<TStore, TService, TModel>(method)
            );

            return !result.IsValid
                ? BadRequest(result.ErrorMessages)
                : Ok(result.Response);

    }
}
