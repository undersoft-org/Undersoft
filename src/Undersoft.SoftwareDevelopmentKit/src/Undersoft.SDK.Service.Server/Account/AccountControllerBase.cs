using Microsoft.AspNetCore.Authorization;

namespace Undersoft.SDK.Service.Application.Account
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.OData.Formatter;
    using System.Text;
    using System.Text.Json;
    using Undersoft.SDK.Security.Identity;
    using Undersoft.SDK.Service;
    using Undersoft.SDK.Service.Client;
    using Undersoft.SDK.Service.Infrastructure.Store;
    using Undersoft.SDK.Service.Server.Controller.Open;
    using Undersoft.SDK.Service.Server.Operation.Command;

    [AllowAnonymous]
    [OpenDataActionService]
    public abstract class AccountControllerBase<TStore, TKind, TService, TDto>
        : OpenDataActionController<TStore, TKind, TService, TDto>
        where TDto : class, IAuthorization, new()
        where TService : class
        where TKind : struct, Enum
        where TStore : IDataServiceStore
    {
        public AccountControllerBase(IServicer servicer) : base(servicer) { }

        [HttpGet($"{StoreRoutes.OpenDataRoute}/[controller]/{nameof(AuthorizationAction.SignIn)}")]
        public virtual async Task<IActionResult> SignIn([FromHeader] string authorization)
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
                    new Execute<TStore, TService, TDto, AuthorizationAction>(
                        AuthorizationAction.SignIn,
                        identityDetails
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? Unauthorized(result.ErrorMessages)
                : Ok(result.Response);
        }

        [HttpPost($"{StoreRoutes.OpenDataRoute}/[controller]/{nameof(AuthorizationAction.SignIn)}")]
        public virtual async Task<IActionResult> SignIn(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var identityDetails = new TDto()
            {
                Credentials = ((JsonElement)parameters[typeof(TDto).Name]).Deserialize<TDto>().Credentials
            };

            var result = await _servicer.Send(
                new Execute<TStore, TService, TDto, AuthorizationAction>(
                    AuthorizationAction.SignIn,
                    identityDetails
                )
            );
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Response);
        }

        [HttpPost($"{StoreRoutes.OpenDataRoute}/[controller]/{nameof(AuthorizationAction.SignUp)}")]
        public virtual async Task<IActionResult> SignUp(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var identityDetails = new TDto()
            {
                Credentials = ((JsonElement)parameters[typeof(TDto).Name]).Deserialize<TDto>().Credentials
            };

            var result = await _servicer
                .Send(
                    new Execute<TStore, TService, TDto, AuthorizationAction>(
                        AuthorizationAction.SignUp,
                        identityDetails
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Response);
        }

        [HttpPost($"{StoreRoutes.OpenDataRoute}/[controller]/{nameof(AuthorizationAction.SignOut)}")]
        public virtual async Task<IActionResult> SignOut(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var identityDetails = new TDto()
            {
                Credentials = ((JsonElement)parameters[typeof(TDto).Name]).Deserialize<TDto>().Credentials
            };

            var result = await _servicer
                .Send(
                    new Execute<TStore, TService, TDto, AuthorizationAction>(
                        AuthorizationAction.SignOut,
                        identityDetails
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Response);
        }

        [HttpPost($"{StoreRoutes.OpenDataRoute}/[controller]/{nameof(AuthorizationAction.Renew)}")]
        public virtual async Task<IActionResult> Renew(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var identityDetails = new TDto()
            {
                Credentials = ((JsonElement)parameters[typeof(TDto).Name]).Deserialize<TDto>().Credentials
            };

            var result = await _servicer
                .Send(
                    new Execute<TStore, TService, TDto, AuthorizationAction>(
                        AuthorizationAction.Renew,
                        identityDetails
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? Unauthorized(result.ErrorMessages)
                : Ok(result.Response);
        }

        [HttpPost($"{StoreRoutes.OpenDataRoute}/[controller]/{nameof(AuthorizationAction.SetPassword)}")]
        public virtual async Task<IActionResult> SetPassword(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicer
                .Send(
                    new Execute<TStore, TService, TDto, AuthorizationAction>(
                        AuthorizationAction.SetPassword,
                        new TDto() { Credentials = ((TDto)parameters[typeof(TDto).Name]).Credentials })
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Response);
        }

        [HttpPost($"{StoreRoutes.OpenDataRoute}/[controller]/{nameof(AuthorizationAction.ConfirmPassword)}")]
        public virtual async Task<IActionResult> ConfirmPassword(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicer
                .Send(
                    new Execute<TStore, TService, TDto, AuthorizationAction>(
                        AuthorizationAction.ConfirmPassword,
                        new TDto() { Credentials = ((JsonElement)parameters[typeof(TDto).Name]).Deserialize<TDto>().Credentials }
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Response);
        }

        [HttpPost($"{StoreRoutes.OpenDataRoute}/[controller]/{nameof(AuthorizationAction.ConfirmEmail)}")]
        public virtual async Task<IActionResult> ConfirmEmail(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicer
                .Send(
                    new Execute<TStore, TService, TDto, AuthorizationAction>(
                        AuthorizationAction.ConfirmEmail,
                        new TDto() { Credentials = ((JsonElement)parameters[typeof(TDto).Name]).Deserialize<TDto>().Credentials }
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Response);
        }

        [HttpPost($"{StoreRoutes.OpenDataRoute}/[controller]/{nameof(AuthorizationAction.CompleteRegistration)}")]
        public virtual async Task<IActionResult> CompleteRegistration(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicer
                .Send(
                    new Execute<TStore, TService, TDto, AuthorizationAction>(
                        AuthorizationAction.CompleteRegistration,
                        new TDto() { Credentials = ((JsonElement)parameters[typeof(TDto).Name]).Deserialize<TDto>().Credentials }
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Response);
        }


    }
}
