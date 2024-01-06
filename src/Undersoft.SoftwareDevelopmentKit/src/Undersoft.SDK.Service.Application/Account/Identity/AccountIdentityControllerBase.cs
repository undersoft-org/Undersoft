using Microsoft.AspNetCore.Authorization;

namespace Undersoft.SDK.Service.Application.Account.Identity
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.OData.Formatter;
    using Microsoft.AspNetCore.OData.Routing.Attributes;
    using System.Net;
    using System.Text;
    using Undersoft.SDK.Security.Identity;
    using Undersoft.SDK.Service;
    using Undersoft.SDK.Service.Application.Controller.Open;
    using Undersoft.SDK.Service.Application.Operation.Command;
    using Undersoft.SDK.Service.Data;

    [AllowAnonymous]
    [OpenDataActionService]
    [ODataRouteComponent("data/open/[controller]")]
    public abstract class AuthorizationControllerBase<TStore, TKind, TService, TDto>
        : OpenDataActionController<TStore, TKind, TService, TDto>
        where TDto : class, IAuthorization, new()
        where TService : class
        where TKind : struct, Enum
        where TStore : IDataServiceStore
    {
        public AuthorizationControllerBase(IServicer servicer) : base(servicer) { }

        [HttpGet(nameof(AuthorizationAction.SignIn))]
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
                    new Execute<IIdentityStore, TService, TDto, AuthorizationAction>(
                        AuthorizationAction.SignIn,
                        identityDetails
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? Unauthorized(result.ErrorMessages)
                : Ok(result.Output.ToString());
        }

        [HttpPost(nameof(AuthorizationAction.SignIn))]
        public virtual async Task<IActionResult> SignIn(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var identityDetails = new TDto()
            {
                Credentials = ((TDto)parameters[typeof(TDto).Name]).Credentials
            };

            var result = await _servicer.Send(
                new Execute<IIdentityStore, TService, TDto, AuthorizationAction>(
                    AuthorizationAction.SignIn,
                    identityDetails
                )
            );
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Id.ToString());
        }

        [HttpPost(nameof(AuthorizationAction.SignUp))]
        public virtual async Task<IActionResult> SignUp(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var identityDetails = new TDto()
            {
                Credentials = ((TDto)parameters[typeof(TDto).Name]).Credentials
            };

            var result = await _servicer
                .Send(
                    new Execute<IIdentityStore, TService, TDto, AuthorizationAction>(
                        AuthorizationAction.SignUp,
                        identityDetails
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Id.ToString());
        }

        [HttpGet(nameof(AuthorizationAction.Renew))]
        public virtual async Task<IActionResult> Renew([FromHeader] string authorization)
        {
            int separator = authorization.IndexOf(' ');

            var identityDetails = new TDto()
            {
                Credentials = new Credentials()
                {
                    SessionToken = authorization.Substring(separator + 1)
                }
            };

            var result = await _servicer
                .Send(
                    new Execute<IIdentityStore, TService, TDto, AuthorizationAction>(
                        AuthorizationAction.Renew,
                        identityDetails
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? Unauthorized(result.ErrorMessages)
                : Ok(result.Output.ToString());
        }

        [HttpPost(nameof(AuthorizationAction.SetPassword))]
        public virtual async Task<IActionResult> SetPassword(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicer
                .Send(
                    new Execute<IIdentityStore, TService, TDto, AuthorizationAction>(
                        AuthorizationAction.SetPassword,
                        new TDto() { Credentials = ((TDto)parameters[typeof(TDto).Name]).Credentials })
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Id.ToString());
        }

        [HttpPost(nameof(AuthorizationAction.SetEmail))]
        public virtual async Task<IActionResult> SetEmail(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicer
                .Send(
                    new Execute<IIdentityStore, TService, TDto, AuthorizationAction>(
                        AuthorizationAction.SetEmail,
                        new TDto() { Credentials = ((TDto)parameters[typeof(TDto).Name]).Credentials }
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Id.ToString());
        }

        [HttpPost(nameof(AuthorizationAction.ConfirmPassword))]
        public virtual async Task<IActionResult> ConfirmPassword(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicer
                .Send(
                    new Execute<IIdentityStore, TService, TDto, AuthorizationAction>(
                        AuthorizationAction.ConfirmPassword,
                        new TDto() { Credentials = ((TDto)parameters[typeof(TDto).Name]).Credentials }
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Id.ToString());
        }

        [HttpPost(nameof(AuthorizationAction.ConfirmEmail))]
        public virtual async Task<IActionResult> ConfirmEmail(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicer
                .Send(
                    new Execute<IIdentityStore, TService, TDto, AuthorizationAction>(
                        AuthorizationAction.ConfirmEmail,
                        new TDto() { Credentials = ((TDto)parameters[typeof(TDto).Name]).Credentials }
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Id.ToString());
        }

        [HttpPost(nameof(AuthorizationAction.CompleteRegistration))]
        public virtual async Task<IActionResult> CompleteRegistration(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicer
                .Send(
                    new Execute<IIdentityStore, TService, TDto, AuthorizationAction>(
                        AuthorizationAction.ConfirmEmail,
                        new TDto() { Credentials = ((TDto)parameters[typeof(TDto).Name]).Credentials }
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Id.ToString());
        }


    }
}
