using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Application.Account;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    [Route($"{StoreRoutes.CrudDataRoute}/[controller]")]
    public class AccountsController
        : CrudDataActionRemoteController<IDataStore, AuthorizationAction, Account, Authorization>
    {
        public AccountsController(IServicer servicer) : base(servicer) { }
    }
}
namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataRoute)]
    public class AccountController
       : OpenDataActionRemoteController<IDataStore, AuthorizationAction, Account, Authorization>
    {
        public AccountController(IServicer servicer) : base(servicer) { }
    }
}
