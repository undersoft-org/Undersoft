using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;

namespace Undersoft.SDK.Service.Server.Controller.Open;

using Uniques;

public interface IOpenServiceController<TKey, TService, TDto> where TDto : class
{
    Task<IActionResult> Post([FromRoute] string method, [FromBody] ODataActionParameters parameters);

    Task<IActionResult> Get([FromRoute] string method, [FromRoute] ODataParameterValue parameter);
}