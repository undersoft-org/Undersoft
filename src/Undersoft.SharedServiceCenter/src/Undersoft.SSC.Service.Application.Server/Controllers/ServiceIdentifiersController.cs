using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Service.Application.Models;
using Undersoft.SSC.Service.Contracts;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Service.Application.Server.Controllers
{

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataRoute)]
    public class ServiceAccountIdentifierController
        : OpenDataRemoteController<long, IDataStore, Identifier<Account>, Identifier<ServiceAccount>>
    {
        public ServiceAccountIdentifierController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.Servicer) { }
    }
}

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    public class ServiceAccountIdentifiersController
        : CrudDataRemoteController<long, IDataStore, Identifier<Account>, Identifier<ServiceAccount>>
    {
        public ServiceAccountIdentifiersController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.Servicer) { }
    }
}
