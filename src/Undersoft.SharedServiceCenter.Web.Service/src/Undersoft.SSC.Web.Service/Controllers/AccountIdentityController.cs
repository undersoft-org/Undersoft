using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Account.Identity;

namespace Undersoft.SSC.Web.API.Controllers
{
    [AllowAnonymous]
    public class AccountIdentityController
        : AccountIdentityControllerBase<IDataStore, AccountIdentityService, AccountIdentity>
    {
        public AccountIdentityController(IServicer servicer) : base(servicer) { }
    }
}
