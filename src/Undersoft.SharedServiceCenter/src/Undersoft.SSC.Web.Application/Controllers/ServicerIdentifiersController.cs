using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.API.Contracts;
using Undersoft.SSC.Web.Application.ViewModels;

namespace Undersoft.SSC.Web.Application.Controllers
{
    using Microsoft.AspNetCore.OData.Routing.Attributes;
    using Undersoft.SDK.Service.Application.Controller.Open;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataStore)]
    public class SubcontractorIdentifierController
        : OpenDataRemoteController<long, IDataStore, Identifier<Account>, Identifier<ViewModels.Servicer>>
    {
        public SubcontractorIdentifierController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.Servicer) { }
    }
}

namespace Undersoft.SSC.Web.Application.Controllers
{
    [AllowAnonymous]
    public class ServicerIdentifiersController
        : CrudDataRemoteController<long, IDataStore, Identifier<Account>, Identifier<ViewModels.Servicer>>
    {
        public ServicerIdentifiersController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.Servicer) { }
    }
}
