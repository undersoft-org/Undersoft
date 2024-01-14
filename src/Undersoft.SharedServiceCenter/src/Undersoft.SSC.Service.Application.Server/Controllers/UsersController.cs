using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Microsoft.AspNetCore.OData.Routing.Attributes;
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
    public class UserMemberController : OpenDataRemoteController<long, IDataStore, Member, UserMember>
    {
        public UserMemberController(IServicer servicer)
            : base(servicer, m => d => d.Group == MemberGroup.User) { }
    }
}

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    public class UserMembersController : CrudDataRemoteController<long, IDataStore, Member, UserMember>
    {
        public UserMembersController(IServicer servicer)
            : base(servicer, m => d => d.Group == MemberGroup.User) { }
    }
}
