using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Data;
using Undersoft.SDK.Service.Data.Store;

namespace Undersoft.SSC.Web.Application.Server.Controllers
{
    [AllowAnonymous]
    [Route($"{StoreRoutes.CrudDataRoute}/[controller]")]
    public class AuthorizationsController
        : CrudDataActionRemoteController<IDataStore, AuthorizationAction, Authorization, Authorization>
    {
        public AuthorizationsController(IServicer servicer) : base(servicer) { }
    }
}
namespace Undersoft.SSC.Web.Application.Server.Controllers
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataRoute)]
    public class AuthorizationController
       : OpenDataActionRemoteController<IDataStore, AuthorizationAction, Authorization, Authorization>
    {
        public AuthorizationController(IServicer servicer) : base(servicer) { }
    }
}
