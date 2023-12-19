using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Enums;

namespace Undersoft.SSC.Web.Application.Server.Server.Controllers
{


    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataStore)]
    public class ServicerrIdentifierController
        : OpenDataRemoteController<long, IDataStore, Identifier<AccountBase>, Identifier<ViewModels.Servicer>>
    {
        public ServicerrIdentifierController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.Servicer) { }
    }
}

namespace Undersoft.SSC.Web.Application.Server.Controllers
{
    [AllowAnonymous]
    public class ServicerIdentifiersController
        : CrudDataRemoteController<long, IDataStore, Identifier<AccountBase>, Identifier<ViewModels.Servicer>>
    {
        public ServicerIdentifiersController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.Servicer) { }
    }
}
