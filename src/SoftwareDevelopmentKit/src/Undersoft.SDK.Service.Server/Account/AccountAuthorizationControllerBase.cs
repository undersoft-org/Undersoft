using Microsoft.AspNetCore.Authorization;

namespace Undersoft.SDK.Service.Server.Accounts
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.OData.Formatter;
    using Microsoft.AspNetCore.OData.Routing.Attributes;
    using System.Text;
    using System.Text.Json;
    using Undersoft.SDK.Security.Identity;
    using Undersoft.SDK.Service;
    using Undersoft.SDK.Service.Client;
    using Undersoft.SDK.Service.Infrastructure.Store;
    using Undersoft.SDK.Service.Server.Controller.Open;
    using Undersoft.SDK.Service.Server.Operation.Command;
    using Undersoft.SDK.Service.Server.Operation.Invocation;

    [AllowAnonymous]
    [OpenService]
    [ODataRouteComponent(StoreRoutes.OpenAuthRoute)]
    public abstract class AccountAuthorizationControllerBase<TStore, TService, TDto>
        : OpenServiceController<TStore, TService, TDto>
        where TDto : class, IAuthorization, new()
        where TService : class
        where TStore : IDataStore
    {
        public AccountAuthorizationControllerBase(IServicer servicer) : base(servicer) { }

        [HttpGet]
        public virtual async Task<IActionResult> Function([FromRoute] string method, [FromHeader] string authorization)
        {
            var encoding = Encoding.GetEncoding("iso-8859-1");
            authorization = encoding.GetString(Convert.FromBase64String(authorization));
            int separator = authorization.IndexOf(':');

            var identityDetails = new TDto()
            {
                Credentials = new Credentials()
                {
                    Email = authorization.Substring(0, separator),
                    Password = authorization.Substring(separator + 1)
                }
            };

            var result = await _servicer
                .Send(
                    new Invoke<TStore, TService, TDto>(
                        method,
                        identityDetails
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? Unauthorized(result.ErrorMessages)
                : Ok(result.Response);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Action([FromRoute] string method, [FromBody] ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var identityDetails = new TDto()
            {
                Credentials = ((JsonElement)parameters[typeof(TDto).Name]).Deserialize<TDto>().Credentials
            };
     
            var result = await _servicer.Send(
                new Invoke<TStore, TService, TDto>(
                    method,
                    identityDetails
                )
            );

            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Ok(result.Response);
        }

    }
}
