using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.ViewModels;

namespace Undersoft.SSC.Web.Application.Controllers
{
    using Microsoft.AspNetCore.OData.Routing.Attributes;
    using Undersoft.SDK.Service.Application.Controller.Open;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataStore)]
    public class ServicerrIdentifierController
        : OpenDataRemoteController<long, IDataStore, Identifier<AccountBase>, Identifier<ViewModels.Servicer>>
    {
        public ServicerrIdentifierController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.Servicer) { }
    }
}

namespace Undersoft.SSC.Web.Application.Controllers
{
    [AllowAnonymous]
    public class ServicerIdentifiersController
        : CrudDataRemoteController<long, IDataStore, Identifier<AccountBase>, Identifier<ViewModels.Servicer>>
    {
        public ServicerIdentifiersController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.Servicer) { }
    }
}
