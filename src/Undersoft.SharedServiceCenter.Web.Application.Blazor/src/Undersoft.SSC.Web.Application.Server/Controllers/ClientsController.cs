using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Appllication.ViewModels;
using Undersoft.SSC.Web.Enums;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Data.Store;

namespace Undersoft.SSC.Web.Application.Server.Controllers
{
  

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataStore)]
    public class ClientController : OpenDataRemoteController<long, IDataStore, AccountBase, Customer>
    {
        public ClientController(IServicer ultimatr)
            : base(ultimatr, c => a => a.Group == AccountGroup.Client) { }
    }
}

namespace Undersoft.SSC.Web.Application.Server.Controllers
{
    public class ClientsController : CrudDataRemoteController<long, IDataStore, AccountBase, Customer>
    {
        public ClientsController(IServicer ultimatr)
            : base(ultimatr, c => a => a.Group == AccountGroup.Client) { }
    }
}
