using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;

namespace Undersoft.SDK.Service.Server.Controller.Open;

using Uniques;

public interface IOpenDataActionRemoteController<TStore, TDto, TModel>
    where TDto : class
    where TModel : class
{
    Task<IActionResult> Post([FromRoute] string method, [FromBody] ODataActionParameters arguments);

    Task<IActionResult> Get([FromRoute] string method, [FromRoute] ODataParameterValue arguments);
}
