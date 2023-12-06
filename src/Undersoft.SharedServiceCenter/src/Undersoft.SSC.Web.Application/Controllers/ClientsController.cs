using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.API.Contracts;
using Undersoft.SSC.Web.Application.ViewModels;

namespace Undersoft.SSC.Web.Application.Controllers
{
    using Undersoft.SDK.Service.Application.Controller.Open;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataStore)]
    public class ClientsController : OpenDataRemoteController<long, IDataStore, Account, Client>
    {
        public ClientsController(IServicer ultimatr)
            : base(ultimatr, c => a => a.Group == AccountGroup.Client) { }
    }
}

namespace Undersoft.SSC.Web.Application.Controllers
{
    public class CustomersController : CrudDataRemoteController<long, IDataStore, Account, Client>
    {
        public CustomersController(IServicer ultimatr)
            : base(ultimatr, c => a => a.Group == AccountGroup.Client) { }
    }
}
