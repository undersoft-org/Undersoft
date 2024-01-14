using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Service.Contracts;
using Undersoft.SSC.Service.Application.Models;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataRoute)]
    public class ClientMemberController : OpenDataRemoteController<long, IDataStore, Member, ClientMember>
    {
        public ClientMemberController(IServicer ultimatr)
            : base(ultimatr, c => a => a.Group == MemberGroup.Client) { }
    }
}

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    public class ClientMembersController : CrudDataRemoteController<long, IDataStore, Member, ClientMember>
    {
        public ClientMembersController(IServicer ultimatr)
            : base(ultimatr, c => a => a.Group == MemberGroup.Client) { }
    }
}
