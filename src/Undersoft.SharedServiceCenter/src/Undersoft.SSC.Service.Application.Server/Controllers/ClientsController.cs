using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service.Server.Controller.Crud;
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
    public class ClientAccountController : OpenDataRemoteController<long, IDataStore, Account, ClientAccount>
    {
        public ClientAccountController(IServicer ultimatr)
            : base(ultimatr, c => a => a.Group == AccountGroup.Client) { }
    }
}

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    public class ClientAccountsController : CrudDataRemoteController<long, IDataStore, Account, ClientAccount>
    {
        public ClientAccountsController(IServicer ultimatr)
            : base(ultimatr, c => a => a.Group == AccountGroup.Client) { }
    }
}
