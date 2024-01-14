using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities.Members;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class MemberDefaultController
        : OpenDataController<long, IEntryStore, IReportStore, MemberDefault, Contracts.Default>
    {
        public MemberDefaultController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class MemberDefaultsController
        : CrudDataController<long, IEntryStore, IReportStore, MemberDefault, Contracts.Default>
    {
        public MemberDefaultsController(IServicer ultimatr) : base(ultimatr) { }
    }
}
