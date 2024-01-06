using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Undersoft.SDK.Service.Application.Controller.Open;

using Microsoft.AspNetCore.OData.Formatter;
using Operation.Command;
using SDK.Service.Data.Store;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Documentation;
using Undersoft.SDK.Service.Application.Operation.Remote.Command;
using Undersoft.SDK.Service.Data;

[IgnoreApi]
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

    public virtual async Task<IActionResult> Post([FromODataUri] string kind, TModel dto)
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

    public virtual async Task<IActionResult> Get([FromODataUri] string kind)
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
