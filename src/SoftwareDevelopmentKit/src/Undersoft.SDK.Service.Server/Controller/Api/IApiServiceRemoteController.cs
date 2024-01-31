using Microsoft.AspNetCore.Mvc;

namespace Undersoft.SDK.Service.Server.Controller.Crud;

using System.Text.Json;
using Undersoft.SDK;


public interface IApiServiceRemoteController<TStore, TService, TModel> where TModel : class, IOrigin where TService : class
{
    Task<IActionResult> Action(string method, [FromBody] Arguments arguments);

    Task<IActionResult> Access(string method, [FromBody] Arguments arguments);

    Task<IActionResult> Setup(string method, [FromBody] Arguments arguments);
}