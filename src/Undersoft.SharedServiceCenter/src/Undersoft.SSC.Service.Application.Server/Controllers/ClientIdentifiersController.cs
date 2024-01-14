using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SSC.Service.Contracts;
using Undersoft.SSC.Service.Application.Models;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataRoute)]
    public class ClientIdentifierController
        : OpenDataRemoteController<
            long,
            IDataStore,
            Identifier<Member>,
            Identifier<ClientMember>
        >
    {
        public ClientIdentifierController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == MemberGroup.Client) { }
    }
}

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    public class ClientIdentifiersController
        : CrudDataRemoteController<
            long,
            IDataStore,
            Identifier<Member>,
            Identifier<ClientMember>
        >
    {
        public ClientIdentifiersController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == MemberGroup.Client) { }
    }
}
