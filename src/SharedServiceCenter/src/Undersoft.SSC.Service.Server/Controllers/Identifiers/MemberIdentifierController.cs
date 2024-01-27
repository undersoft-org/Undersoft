using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Service.Server.Controllers.Identifiers
{
    [AllowAnonymous]
    [ApiVersion("OPEN")]
    public class MemberIdentifierController
        : OpenCqrsController<long, IEntryStore, IReportStore, Identifier<Member>, Identifier<Contracts.Member>, ServiceManager>
    {
        public MemberIdentifierController(IServicer servicer) : base(servicer) { }
    }

    [ApiVersion("REST")]
    [Route($"{StoreRoutes.ApiDataRoute}/MemberIdentifier")]
    public class MemberIdentifiersController
        : ApiCqrsController<long, IEntryStore, IReportStore, Identifier<Member>, Identifier<Contracts.Member>, ServiceManager>
    {
        public MemberIdentifiersController(IServicer servicer) : base(servicer) { }
    }
}

