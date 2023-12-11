using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.ViewModels;

namespace Undersoft.SSC.Web.Application.Controllers
{
    using Microsoft.AspNetCore.OData.Routing.Attributes;
    using Undersoft.SDK.Service.Application.Controller.Open;
    using Undersoft.SSC.Domain.Entities.Enums;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataStore)]
    public class UserController : OpenDataRemoteController<long, IDataStore, AccountBase, User>
    {
        public UserController(IServicer servicer)
            : base(servicer, m => d => d.Group == AccountGroup.User) { }
    }
}

namespace Undersoft.SSC.Web.Application.Controllers
{
    [AllowAnonymous]
    public class UsersController : CrudDataRemoteController<long, IDataStore, AccountBase, User>
    {
        public UsersController(IServicer servicer)
            : base(servicer, m => d => d.Group == AccountGroup.User) { }
    }
}
