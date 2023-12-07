using Microsoft.AspNetCore.Authorization;

namespace Undersoft.SDK.Service.Application.Account.Identity
{
    using Undersoft.SDK.Service.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.OData.Formatter;
    using Microsoft.AspNetCore.OData.Routing.Attributes;
    using System.Text;
    using Undersoft.SDK.Service;
    using Undersoft.SDK.Service.Application.Controller.Open;
    using Undersoft.SDK.Service.Application.Operation.Command;

    [AllowAnonymous]
    [OpenDataActionService]
    [ODataRouteComponent("data/open/[controller]")]
    public abstract class AccountIdentityControllerBase<TStore, TService, TDto>
        : OpenDataActionController<TStore, TService, TDto, ActionServiceKind>
        where TDto : class, IAccountIdentity<long>, new()
        where TService : class
        where TStore : IDataServiceStore
    {
        public AccountIdentityControllerBase(IServicer servicer) : base(servicer) { }

        [HttpPost(nameof(ActionServiceKind.SignIn))]
        public virtual async Task<IActionResult> SignIn(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var identityDetails = new TDto()
            {
                Credentials = (AccountIdentityCredentials)parameters["credentials"]
            };

            var result = await _servicer.Send(
                new Execute<IIdentityStore, TService, TDto, ActionServiceKind>(
                    ActionServiceKind.SignIn,
                    identityDetails
                )
            );
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Id.ToString());
        }

        [HttpPost(nameof(ActionServiceKind.SignUp))]
        public virtual async Task<IActionResult> SignUp(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var identityDetails = new TDto()
            {
                Credentials = (AccountIdentityCredentials)parameters["credentials"]
            };

            var result = await _servicer
                .Send(
                    new Execute<IIdentityStore, TService, TDto, ActionServiceKind>(
                        ActionServiceKind.SignUp,
                        identityDetails
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Id.ToString());
        }

        [HttpPost(nameof(ActionServiceKind.SetPassword))]
        public virtual async Task<IActionResult> SetPassword(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicer
                .Send(
                    new Execute<IIdentityStore, TService, TDto, ActionServiceKind>(
                        ActionServiceKind.SetPassword,
                        new TDto() { Credentials = (AccountIdentityCredentials)parameters["credentials"] })
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Id.ToString());
        }

        [HttpPost(nameof(ActionServiceKind.SetEmail))]
        public virtual async Task<IActionResult> SetEmail(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicer
                .Send(
                    new Execute<IIdentityStore, TService, TDto, ActionServiceKind>(
                        ActionServiceKind.SetEmail,
                        new TDto() { Credentials = (AccountIdentityCredentials)parameters["credentials"] }
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Id.ToString());
        }

        [HttpPost(nameof(ActionServiceKind.ConfirmPassword))]
        public virtual async Task<IActionResult> ConfirmPassword(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicer
                .Send(
                    new Execute<IIdentityStore, TService, TDto, ActionServiceKind>(
                        ActionServiceKind.ConfirmPassword,
                        new TDto() { Credentials = (AccountIdentityCredentials)parameters["credentials"] }
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Id.ToString());
        }

        [HttpPost(nameof(ActionServiceKind.ConfirmEmail))]
        public virtual async Task<IActionResult> ConfirmEmail(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicer
                .Send(
                    new Execute<IIdentityStore, TService, TDto, ActionServiceKind>(
                        ActionServiceKind.ConfirmEmail,
                        new TDto() { Credentials = (AccountIdentityCredentials)parameters["credentials"] }
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Id.ToString());
        }

        [HttpPost(nameof(ActionServiceKind.CompleteRegistration))]
        public virtual async Task<IActionResult> CompleteRegistration(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicer
                .Send(
                    new Execute<IIdentityStore, TService, TDto, ActionServiceKind>(
                        ActionServiceKind.ConfirmEmail,
                        new TDto() { Credentials = (AccountIdentityCredentials)parameters["credentials"] }
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Id.ToString());
        }

        [HttpPost(nameof(ActionServiceKind.Token))]
        public virtual async Task<IActionResult> Token(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicer
                .Send(
                    new Execute<IIdentityStore, TService, TDto, ActionServiceKind>(
                        ActionServiceKind.Token,
                        new TDto() { Credentials = (AccountIdentityCredentials)parameters["credentials"] })
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Id.ToString());
        }

        [HttpGet(nameof(ActionServiceKind.Token))]
        public virtual async Task<IActionResult> Get([FromHeader] string authorization)
        {
            var encoding = Encoding.GetEncoding("iso-8859-1");
            authorization = encoding.GetString(Convert.FromBase64String(authorization));
            int separator = authorization.IndexOf(':');

            var identityDetails = new TDto()
            {
                Credentials = new AccountIdentityCredentials()
                {
                    Email = authorization.Substring(0, separator),
                    Password = authorization.Substring(separator + 1)
                }
            };

            var result = await _servicer
                .Send(
                    new Execute<IIdentityStore, TService, TDto, ActionServiceKind>(
                        ActionServiceKind.Token,
                        identityDetails
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? Unauthorized(result.ErrorMessages)
                : Ok(result.Output.ToString());
        }
    }
}
