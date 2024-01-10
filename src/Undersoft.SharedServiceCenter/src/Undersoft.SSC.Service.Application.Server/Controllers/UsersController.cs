using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Service.Contracts;
using Undersoft.SSC.Service.Application.Models;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataRoute)]
    public class UserAccountController : OpenDataRemoteController<long, IDataStore, Account, UserAccount>
    {
        public UserAccountController(IServicer servicer)
            : base(servicer, m => d => d.Group == AccountGroup.User) { }
    }
}

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    public class UserAccountsController : CrudDataRemoteController<long, IDataStore, Account, UserAccount>
    {
        public UserAccountsController(IServicer servicer)
            : base(servicer, m => d => d.Group == AccountGroup.User) { }
    }
}
