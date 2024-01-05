
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Undersoft.SDK.Security.Identity;

namespace Undersoft.SDK.Service.Application;

public class ApplicationHostJwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServicer _servicer;

    public ApplicationHostJwtMiddleware(RequestDelegate next, IServicer servicer)
    {
        _next = next;
        _servicer = servicer;
    }

    public async Task Invoke(HttpContext context)
    {
        var auth = _servicer.GetService<IAuthorization>();
        auth.Credentials.SessionToken = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").LastOrDefault();
        await _next(context);
    }
}