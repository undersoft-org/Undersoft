using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Accounts;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController
        : OpenServiceController<IAccountStore, AccountService, Authorization>
    {
        public AuthorizationController(IServicer servicer) : base(servicer) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class AuthorizationsController
        : ApiServiceController<IAccountStore, AccountService, Authorization>
    {
        public AuthorizationsController(IServicer servicer) : base(servicer) { }

        [HttpPost(StoreRoutes.ApiAuthRoute + "/Authorization/{method}")]
        public override async Task<IActionResult> Post(
            [FromRoute] string method,
            [FromBody] Dictionary<string, object> dto
        )
        {
            return await base.Post(method, dto);
        }

        [HttpGet(StoreRoutes.ApiAuthRoute + "/Authorization/{method}")]
        public override async Task<IActionResult> Get([FromRoute] string method)
        {
            return await base.Get(method);
        }
    }
}
