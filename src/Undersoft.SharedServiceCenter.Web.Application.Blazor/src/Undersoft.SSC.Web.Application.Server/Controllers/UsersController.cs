using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Application.ViewModels;
using Undersoft.SSC.Web.Enums;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Data.Store;

namespace Undersoft.SSC.Web.Application.Server.Controllers
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataStore)]
    public class UserController : OpenDataRemoteController<long, IDataStore, AccountBase, User>
    {
        public UserController(IServicer servicer)
            : base(servicer, m => d => d.Group == AccountGroup.User) { }
    }
}

namespace Undersoft.SSC.Web.Application.Server.Controllers
{
    [AllowAnonymous]
    public class UsersController : CrudDataRemoteController<long, IDataStore, AccountBase, User>
    {
        public UsersController(IServicer servicer)
            : base(servicer, m => d => d.Group == AccountGroup.User) { }
    }
}
