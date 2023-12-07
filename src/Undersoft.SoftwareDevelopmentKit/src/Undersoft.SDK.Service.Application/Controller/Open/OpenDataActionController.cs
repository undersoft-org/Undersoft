using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Undersoft.SDK.Service.Application.Controller.Open;

using Operation.Command;
using SDK.Service.Data.Store;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data;

[OpenDataActionService]
public abstract class OpenDataActionController<TStore, TType, TDto, TKind>
    : ODataController, IOpenDataActionController<TStore, TType, TDto, TKind> where TDto : class where TKind : struct, Enum
    where TType : class
    where TStore : IDataServiceStore
{
    protected readonly IServicer _servicer;
    protected readonly TKind _kind;

    protected OpenDataActionController() { }

    public OpenDataActionController(
        IServicer servicer,
        TKind kind = default(TKind)
    )
    {
        _servicer = servicer;
        _kind = kind;
    }

    [HttpPost]
    public virtual async Task<IActionResult> Post(TDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _servicer.Send(new Execute<TStore, TType, TDto, TKind>
                                                (_kind, dto))
                                                    .ConfigureAwait(false);
        return !result.IsValid
               ? UnprocessableEntity(result.ErrorMessages)
               : Created(result.Id.ToString());
    }
}
