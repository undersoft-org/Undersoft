using Microsoft.AspNetCore.Authorization;

namespace Undersoft.SDK.Service.Server.Accounts
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.AspNetCore.OData.Formatter;
    using Microsoft.AspNetCore.OData.Routing.Attributes;
    using ServiceStack.Text;
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
    [ODataRouteComponent(StoreRoutes.OpenDataRoute)]
    public abstract class AccountControllerBase<TStore, TKind, TService, TDto>
        : OpenDataActionController<TStore, TKind, TService, TDto>
        where TDto : class, IAuthorization, new()
        where TService : class
        where TKind : struct, Enum
        where TStore : IDataStore
    {
        public AccountControllerBase(IServicer servicer) : base(servicer) { }

        [HttpGet(StoreRoutes.OpenDataRoute+ "/Authorization")]
        public virtual async Task<IActionResult> Function([FromHeader] string authorization)
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
                    new Execute<TStore, TService, TDto, AccountAction>(
                        AccountAction.SignIn,
                        identityDetails
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? Unauthorized(result.ErrorMessages)
                : Ok(result.Response);
        }

        [HttpPost(StoreRoutes.OpenDataRoute + "/Authorization({action})")]
        public virtual async Task<IActionResult> Action([FromRoute] string action, ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var identityDetails = new TDto()
            {
                Credentials = ((JsonElement)parameters[typeof(TDto).Name]).Deserialize<TDto>().Credentials
            };
            AccountAction actionEnum = AccountAction.None;
            if (!Enum.TryParse<AccountAction>(action, out actionEnum))
                return BadRequest(ModelState);

            var result = await _servicer.Send(
                new Execute<TStore, TService, TDto, AccountAction>(
                    actionEnum,
                    identityDetails
                )
            );

            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Response);
        }

        [HttpPost(StoreRoutes.OpenDataRoute + "/Authorization/SignIn")]
        public virtual async Task<IActionResult> SignIn(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var identityDetails = new TDto()
            {
                Credentials = ((JsonElement)parameters[typeof(TDto).Name]).Deserialize<TDto>().Credentials
            };

            var result = await _servicer.Send(
                new Execute<TStore, TService, TDto, AccountAction>(
                    AccountAction.SignIn,
                    identityDetails
                )
            );
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Response);
        }

        [HttpPost($"{StoreRoutes.OpenDataRoute}/[controller]/{nameof(AccountAction.SignUp)}")]
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
                    new Execute<TStore, TService, TDto, AccountAction>(
                        AccountAction.SignUp,
                        identityDetails
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Response);
        }

        [HttpPost($"{StoreRoutes.OpenDataRoute}/[controller]/{nameof(AccountAction.SignOut)}")]
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
                    new Execute<TStore, TService, TDto, AccountAction>(
                        AccountAction.SignOut,
                        identityDetails
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Response);
        }

        [HttpPost($"{StoreRoutes.OpenDataRoute}/[controller]/{nameof(AccountAction.Renew)}")]
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
                    new Execute<TStore, TService, TDto, AccountAction>(
                        AccountAction.Renew,
                        identityDetails
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? Unauthorized(result.ErrorMessages)
                : Ok(result.Response);
        }

        [HttpPost($"{StoreRoutes.OpenDataRoute}/[controller]/{nameof(AccountAction.SetPassword)}")]
        public virtual async Task<IActionResult> SetPassword(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicer
                .Send(
                    new Execute<TStore, TService, TDto, AccountAction>(
                        AccountAction.SetPassword,
                        new TDto() { Credentials = ((TDto)parameters[typeof(TDto).Name]).Credentials })
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Response);
        }

        [HttpPost($"{StoreRoutes.OpenDataRoute}/Authorization/{nameof(AccountAction.ConfirmPassword)}")]
        public virtual async Task<IActionResult> ConfirmPassword(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicer
                .Send(
                    new Execute<TStore, TService, TDto, AccountAction>(
                        AccountAction.ConfirmPassword,
                        new TDto() { Credentials = ((JsonElement)parameters[typeof(TDto).Name]).Deserialize<TDto>().Credentials }
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Response);
        }

        [HttpPost($"{StoreRoutes.OpenDataRoute}/[controller]/{nameof(AccountAction.ConfirmEmail)}")]
        public virtual async Task<IActionResult> ConfirmEmail(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicer
                .Send(
                    new Execute<TStore, TService, TDto, AccountAction>(
                        AccountAction.ConfirmEmail,
                        new TDto() { Credentials = ((JsonElement)parameters[typeof(TDto).Name]).Deserialize<TDto>().Credentials }
                    )
                )
                .ConfigureAwait(false);
            return !result.IsValid
                ? UnprocessableEntity(result.ErrorMessages)
                : Created(result.Response);
        }

        [HttpPost($"{StoreRoutes.OpenDataRoute}/[controller]/{nameof(AccountAction.CompleteRegistration)}")]
        public virtual async Task<IActionResult> CompleteRegistration(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicer
                .Send(
                    new Execute<TStore, TService, TDto, AccountAction>(
                        AccountAction.CompleteRegistration,
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
