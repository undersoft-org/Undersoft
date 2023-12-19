using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Enums;
using Undersoft.SSC.Web.ViewModels;

using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Data.Store;

namespace Undersoft.SSC.Web.Application.Server.Controllers
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataStore)]
    public class ServicerController
        : OpenDataRemoteController<long, IDataStore, AccountBase, ViewModels.Servicer>
    {
        public ServicerController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Group == AccountGroup.Servicer) { }
    }
}

namespace Undersoft.SSC.Web.Application.Server.Controllers
{
    [AllowAnonymous]
    public class ServicersController
        : CrudDataRemoteController<long, IDataStore, AccountBase, ViewModels.Servicer>
    {
        public ServicersController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Group == AccountGroup.Servicer) { }
    }
}
