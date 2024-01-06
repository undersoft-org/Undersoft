using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Application.ViewModels;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Data.Store;

namespace Undersoft.SSC.Web.Application.Server.Controllers
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataRoute)]
    public class ClientAccountController : OpenDataRemoteController<long, IDataStore, Account, ClientAccount>
    {
        public ClientAccountController(IServicer ultimatr)
            : base(ultimatr, c => a => a.Group == AccountGroup.Client) { }
    }
}

namespace Undersoft.SSC.Web.Application.Server.Controllers
{
    public class ClientAccountsController : CrudDataRemoteController<long, IDataStore, Account, ClientAccount>
    {
        public ClientAccountsController(IServicer ultimatr)
            : base(ultimatr, c => a => a.Group == AccountGroup.Client) { }
    }
}
