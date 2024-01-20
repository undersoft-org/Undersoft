using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Undersoft.SDK.Service.Server.Controller.Open;

using Operation.Command;

using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data;
using Undersoft.SDK.Service.Infrastructure.Store;

[OpenDataActionService]
public abstract class OpenDataActionController<TStore, TKind, TType, TDto>
    : ODataController, IOpenDataActionController<TStore, TKind, TType, TDto> where TDto : class where TKind : struct, Enum
    where TType : class
    where TStore : IDataServerStore
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
}
