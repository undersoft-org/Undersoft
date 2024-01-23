using Microsoft.AspNetCore.Mvc;

namespace Undersoft.SDK.Service.Server.Controller.Crud;

using System.Text.Json;
using Undersoft.SDK;


public interface IApiServiceRemoteController<TStore, TService, TModel> where TModel : class, IOrigin where TService : class
{
    Task<IActionResult> Post([FromRoute] string method, [FromBody] Dictionary<string, object> arguments);

    Task<IActionResult> Get([FromRoute] string method);
}