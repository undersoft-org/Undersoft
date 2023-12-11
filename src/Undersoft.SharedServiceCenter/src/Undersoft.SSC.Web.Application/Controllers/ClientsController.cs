using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Appllication.ViewModels;

namespace Undersoft.SSC.Web.Application.Controllers
{
    using Undersoft.SDK.Service.Application.Controller.Open;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataStore)]
    public class ClientController : OpenDataRemoteController<long, IDataStore, AccountBase, Client>
    {
        public ClientController(IServicer ultimatr)
            : base(ultimatr, c => a => a.Group == AccountGroup.Client) { }
    }
}

namespace Undersoft.SSC.Web.Application.Controllers
{
    public class ClientsController : CrudDataRemoteController<long, IDataStore, AccountBase, Client>
    {
        public ClientsController(IServicer ultimatr)
            : base(ultimatr, c => a => a.Group == AccountGroup.Client) { }
    }
}
