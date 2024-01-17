using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Account;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController
        : AccountControllerBase<IDataStore, AccountAction, AccountService, Authorization>
    {
        public AuthorizationController(IServicer servicer) : base(servicer) { }
    }
}
