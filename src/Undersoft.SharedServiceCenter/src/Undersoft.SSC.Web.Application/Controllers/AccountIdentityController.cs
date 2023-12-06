using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Account;
using Undersoft.SDK.Service.Application.Operation.Command;
using Undersoft.SDK.Service.Application.Operation.Remote.Command;
using Undersoft.SDK.Service.Application.Account.Identity;

namespace Undersoft.SSC.Web.Application.Controllers
{
    [AllowAnonymous]
    [Route($"{StoreRoutes.CrudDataStore}/[controller]")]
    public class AccountIdentityController
        : CrudDataActionRemoteController<IDataStore, AccountIdentity, AccountIdentity>
    {
        public AccountIdentityController(IServicer servicer) : base(servicer) { }

        [HttpGet]
        public virtual async Task<IActionResult> Get([FromHeader] string authorization)
        {
            var encoding = Encoding.GetEncoding("iso-8859-1");
            authorization = encoding.GetString(Convert.FromBase64String(authorization));
            int separator = authorization.IndexOf(':');

            var dto = new AccountIdentity()
            {
                Credentials = new AccountIdentityCredentials()
                {
                    Email = authorization.Substring(0, separator),
                    Password = authorization.Substring(separator + 1)
                }
            };

            var result = await _servicer
                .Send<ActionCommand<AccountIdentity>>(
                    new RemoteExecute<IDataStore, AccountIdentity, AccountIdentity>(_kind, dto)
                )
                .ConfigureAwait(false);

            return !result.IsValid
                ? Unauthorized(result.ErrorMessages)
                : Ok(result.Output.ToString());
        }
    }
}
