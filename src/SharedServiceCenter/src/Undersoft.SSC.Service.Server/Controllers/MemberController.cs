using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SSC.Domain.Entities;


namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class MemberController
        : OpenDataController<long, IEntryStore, IReportStore, Member, Contracts.Member>
    {
        public MemberController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class MembersController
        : CrudDataController<long, IEntryStore, IReportStore, Member, Contracts.Member>
    {
        public MembersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

