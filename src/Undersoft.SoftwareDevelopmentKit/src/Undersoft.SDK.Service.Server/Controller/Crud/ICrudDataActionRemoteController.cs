using Microsoft.AspNetCore.Mvc;

namespace Undersoft.SDK.Service.Server.Controller.Crud;

using Undersoft.SDK;


public interface ICrudDataActionRemoteController<TStore, TKind, TDto, TModel> where TDto : class, IOrigin where TModel : class, IOrigin where TKind : Enum
{
    Task<IActionResult> Post([FromRoute] string kind, [FromBody] TModel dto);

    Task<IActionResult> Get([FromRoute] string kind);
}