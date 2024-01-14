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
    public class ServiceMemberController
        : OpenDataRemoteController<long, IDataStore, MemberBase, ServiceMember>
    {
        public ServiceMemberController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Group == MemberGroup.Servitizer) { }
    }
}

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    public class ServiceMembersController
        : CrudDataRemoteController<long, IDataStore, MemberBase, ServiceMember>
    {
        public ServiceMembersController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Group == MemberGroup.Servitizer) { }
    }
}
