using Microsoft.AspNetCore.Mvc;

namespace Undersoft.SDK.Service.Application.Controller.Crud;

using Data.Service;
using Operation.Remote.Command;
using Undersoft.SDK;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data;

[ApiController]
[RemoteCrudDataActionService]
[Route($"{StoreRoutes.CrudIdentityStore}/[controller]")]
public abstract class CrudDataActionRemoteController<TStore, TDto, TModel, TKind>
    : ControllerBase, ICrudDataActionRemoteController<TStore, TDto, TModel, TKind>
    where TModel : class, IOrigin
    where TDto : class, IOrigin
    where TKind : struct, Enum
    where TStore : IDataServiceStore
{
    protected readonly IServicer _servicer;
    protected readonly AuthorizationAction _kind;

    protected CrudDataActionRemoteController() { }

    protected CrudDataActionRemoteController(
        IServicer servicer,
        AuthorizationAction kind = AuthorizationAction.None
    )
    {
        _servicer = servicer;
        _kind = kind;
    }

    [HttpPost("{kind}")]
    public virtual async Task<IActionResult> Post([FromRoute] string kind, [FromBody] TModel dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (Enum.TryParse(kind, out TKind method))
        {
            var result = await _servicer
                .Send(new RemoteExecute<TStore, TDto, TModel, TKind>(method, dto));

            return !result.IsValid
                   ? UnprocessableEntity(result.ErrorMessages)
                   : Ok(result.Response);
        }
        return NotFound(kind);
    }
}
