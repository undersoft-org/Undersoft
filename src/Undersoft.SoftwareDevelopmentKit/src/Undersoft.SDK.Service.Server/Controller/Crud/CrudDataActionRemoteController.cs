using Microsoft.AspNetCore.Mvc;

namespace Undersoft.SDK.Service.Server.Controller.Crud;
using Operation.Remote.Command;
using Undersoft.SDK;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Server.Operation.Command;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Client.Remote;

[ApiController]
[RemoteCrudDataActionService]
[Route($"{StoreRoutes.CrudIdentityRoute}/[controller]")]
public abstract class CrudDataActionRemoteController<TStore, TKind, TDto, TModel>
    : ControllerBase,
        ICrudDataActionRemoteController<TStore, TKind, TDto, TModel>
    where TModel : class, IOrigin
    where TDto : class, IOrigin
    where TKind : struct, Enum
    where TStore : IDataServiceStore
{    
    protected readonly IServicer _servicer;    

    protected CrudDataActionRemoteController() { }

    protected CrudDataActionRemoteController(
        IServicer servicer
    )
    {
        _servicer = servicer;            
    }

    [HttpPost("{kind}")]
    public virtual async Task<IActionResult> Post([FromRoute] string kind, [FromBody] TModel dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (Enum.TryParse(kind, out TKind method))
        {
            var result = await _servicer.Send(
                new RemoteExecute<TStore, TDto, TModel, TKind>(method, dto, CommandMode.Action)
            );

            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Ok(result.Response);
        }
        return NotFound(kind);
    }

    [HttpGet("{kind}")]
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
