using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Application.Models;
using Undersoft.SSC.Service.Contracts.Base;

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataRoute)]
    public class ServiceAccountController
        : OpenDataRemoteController<long, IDataStore, AccountBase, ServiceAccount>
    {
        public ServiceAccountController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Group == AccountGroup.Servicer) { }
    }
}

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    public class ServiceAccountsController
        : CrudDataRemoteController<long, IDataStore, AccountBase, ServiceAccount>
    {
        public ServiceAccountsController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Group == AccountGroup.Servicer) { }
    }
}
