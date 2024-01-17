using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Service.Application.Models;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataRoute)]
    public class MemberController : OpenDataController<long, IEntryStore, IReportStore, Contracts.Member, Contracts.Member>
    {
        public MemberController(IServicer ultimatr)
            : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    public class MembersController : CrudDataController<long, IEntryStore, IReportStore, Contracts.Member, Contracts.Member>
    {
        public MembersController(IServicer ultimatr)
            : base(ultimatr) { }
    }
}
