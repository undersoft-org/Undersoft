using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Web.Application.Server.Controllers
{

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataStore)]
    public class ServiceAccountIdentifierController
        : OpenDataRemoteController<long, IDataStore, Identifier<Account>, Identifier<ViewModels.ServiceAccount>>
    {
        public ServiceAccountIdentifierController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.Servicer) { }
    }
}

namespace Undersoft.SSC.Web.Application.Server.Controllers
{
    [AllowAnonymous]
    public class ServiceAccountIdentifiersController
        : CrudDataRemoteController<long, IDataStore, Identifier<Account>, Identifier<ViewModels.ServiceAccount>>
    {
        public ServiceAccountIdentifiersController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.Servicer) { }
    }
}
