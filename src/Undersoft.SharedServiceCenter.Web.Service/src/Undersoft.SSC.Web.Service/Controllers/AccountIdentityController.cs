using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Account.Identity;
using Undersoft.SDK.Service.Data;

namespace Undersoft.SSC.Web.Controllers
{
    [AllowAnonymous]
    public class AccountIdentityController
        : AccountIdentityControllerBase<IDataStore, AccountIdentityService, AccountIdentity, AccountIdentityAction>
    {
        public AccountIdentityController(IServicer servicer) : base(servicer) { }
    }
}
