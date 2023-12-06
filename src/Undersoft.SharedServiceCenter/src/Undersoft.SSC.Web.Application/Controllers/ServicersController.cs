using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.API.Contracts;
using Undersoft.SSC.Web.Application.ViewModels;

namespace Undersoft.SSC.Web.Application.Controllers
{
    using Microsoft.AspNetCore.OData.Routing.Attributes;
    using Undersoft.SDK.Service.Application.Controller.Open;
    using Undersoft.SSC.Domain.Entities.Enums;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataStore)]
    public class ServicersController
        : OpenDataRemoteController<long, IDataStore, Account, ViewModels.Servicer>
    {
        public ServicersController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Group == AccountGroup.Servicer) { }
    }
}

namespace Undersoft.SSC.Web.Application.Controllers
{
    [AllowAnonymous]
    public class SubcontractorsController
        : CrudDataRemoteController<long, IDataStore, Account, ViewModels.Servicer>
    {
        public SubcontractorsController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Group == AccountGroup.Servicer) { }
    }
}
