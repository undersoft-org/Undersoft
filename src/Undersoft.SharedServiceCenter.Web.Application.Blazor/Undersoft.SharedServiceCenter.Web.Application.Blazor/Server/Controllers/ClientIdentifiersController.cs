using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SSC.Web.Contracts;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SSC.Web.Enums;
using Undersoft.SSC.Web.Appllication.ViewModels;

namespace Undersoft.SSC.Web.Application.Server.Server.Controllers
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataStore)]
    public class ClientIdentifierController
        : OpenDataRemoteController<
            long,
            IDataStore,
            Identifier<AccountBase>,
            Identifier<Customer>
        >
    {
        public ClientIdentifierController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.Client) { }
    }
}

namespace Undersoft.SSC.Web.Application.Server.Controllers
{
    [AllowAnonymous]
    public class ClientIdentifiersController
        : CrudDataRemoteController<
            long,
            IDataStore,
            Identifier<AccountBase>,
            Identifier<Customer>
        >
    {
        public ClientIdentifiersController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.Client) { }
    }
}
