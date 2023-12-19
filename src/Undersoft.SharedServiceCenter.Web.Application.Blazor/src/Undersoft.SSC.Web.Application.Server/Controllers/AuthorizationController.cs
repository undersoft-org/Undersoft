using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Data;
using Undersoft.SDK.Service.Data.Store;

namespace Undersoft.SSC.Web.Application.Server.Controllers
{
    [AllowAnonymous]
    [Route($"{StoreRoutes.CrudDataStore}/[controller]")]
    public class AuthorizationController
        : CrudDataActionRemoteController<IDataStore, Authorization, Authorization, AuthorizationAction>
    {
        public AuthorizationController(IServicer servicer) : base(servicer) { }
    }
}
