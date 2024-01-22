using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataRoute)]
    public class MemberController
        : OpenCqrsController<
            long,
            IEntryStore,
            IReportStore,
            Domain.Entities.Member,
            Contracts.Member
        >
    {
        public MemberController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class MembersController
        : ApiCqrsController<
            long,
            IEntryStore,
            IReportStore,
            Domain.Entities.Member,
            Contracts.Member
        >
    {
        public MembersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class MemberStreamController
        : StreamDataController<
            long,
            IEntryStore,
            IReportStore,
            Domain.Entities.Member,
            Contracts.Member
        >
    {
        public MemberStreamController() : base() { }
    }
}
