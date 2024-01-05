using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Application.Account.Identity;
using Undersoft.SDK.Service.Data;

namespace Undersoft.SSC.Web.Service.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController
        : AuthorizationControllerBase<IDataStore, AuthorizationService, Authorization, AuthorizationAction>
    {
        public AuthorizationController(IServicer servicer) : base(servicer) { }
    }
}
