using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SSC.Entities.Members;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class MemberIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Member>, Identifier<Contracts.Member>>
    {
        public MemberIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class MemberIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Member>, Identifier<Contracts.Member>>
    {
        public MemberIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

