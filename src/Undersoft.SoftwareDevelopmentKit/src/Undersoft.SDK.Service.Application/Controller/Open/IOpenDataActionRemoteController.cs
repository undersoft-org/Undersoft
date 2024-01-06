using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;

namespace Undersoft.SDK.Service.Application.Controller.Open;

using Uniques;

public interface IOpenDataActionRemoteController<TStore, TKind, TDto, TModel>
    where TDto : class, IOrigin
    where TModel : class, IOrigin
    where TKind : Enum
{
    Task<IActionResult> Post([FromODataUri] string kind, ODataActionParameters dto);

    Task<IActionResult> Get([FromODataUri] string kind);
}
