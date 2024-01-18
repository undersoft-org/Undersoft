using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Server.Account;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    [Route($"{StoreRoutes.CrudDataRoute}/Accounts/Authorization")]
    public class AccountAuthorizationController
        : CrudDataActionRemoteController<IDataStore, AccountAction, Authorization, Authorization>
    {
        public AccountAuthorizationController(IServicer servicer) : base(servicer) { }
    }
}
namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController
       : OpenDataActionRemoteController<IDataStore, AccountAction, Authorization, Authorization>
    {
        public AuthorizationController(IServicer servicer) : base(servicer) { }
    }
}
