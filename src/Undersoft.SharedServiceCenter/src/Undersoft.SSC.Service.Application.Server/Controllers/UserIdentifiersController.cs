using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SSC.Entities.Members;
using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Application.Models;

namespace Undersoft.SSC.Service.Application.Server.Controllers
{

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataRoute)]
    public class UserMemberIdentifierController
        : OpenDataRemoteController<long, IDataStore, Identifier<Member>, Identifier<UserMember>>
    {
        public UserMemberIdentifierController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == MemberGroup.User) { }
    }
}

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    public class UserMemberIdentifiersController
        : CrudDataRemoteController<long, IDataStore, Identifier<Member>, Identifier<UserMember>>
    {
        public UserMemberIdentifiersController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == MemberGroup.User) { }
    }
}
