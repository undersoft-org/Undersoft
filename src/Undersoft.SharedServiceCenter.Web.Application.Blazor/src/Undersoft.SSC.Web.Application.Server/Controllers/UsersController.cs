using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Application.ViewModels;
using Undersoft.SSC.Domain.Entities.Enums;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Data.Store;

namespace Undersoft.SSC.Web.Application.Server.Controllers
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataRoute)]
    public class UserAccountController : OpenDataRemoteController<long, IDataStore, Account, UserAccount>
    {
        public UserAccountController(IServicer servicer)
            : base(servicer, m => d => d.Group == AccountGroup.User) { }
    }
}

namespace Undersoft.SSC.Web.Application.Server.Controllers
{
    [AllowAnonymous]
    public class UserAccountsController : CrudDataRemoteController<long, IDataStore, Account, UserAccount>
    {
        public UserAccountsController(IServicer servicer)
            : base(servicer, m => d => d.Group == AccountGroup.User) { }
    }
}
