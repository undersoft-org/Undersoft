using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class MemberIdentifierController
        : OpenCqrsController<long, IEntryStore, IReportStore, Identifier<Member>, Identifier<Contracts.Member>>
    {
        public MemberIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    [Route($"{StoreRoutes.ApiDataRoute}/MemberIdentifier")]
    public class MemberIdentifiersController
        : ApiCqrsController<long, IEntryStore, IReportStore, Identifier<Member>, Identifier<Contracts.Member>>
    {
        public MemberIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

