using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Server.Account.Identity;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController
        : AuthorizationControllerBase<IDataStore, AuthorizationAction, AuthorizationService, Authorization>
    {
        public AuthorizationController(IServicer servicer) : base(servicer) { }
    }
}
