using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Accounts;
using Undersoft.SDK.Service.Server.Controller.Open;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenAuthRoute+"/Account")]
    public class AccountServiceController
        : OpenServiceController<IAccountStore, AccountService, Contracts.Account>
    {
        public AccountServiceController(IServicer servicer) : base(servicer) { }
    }
}
