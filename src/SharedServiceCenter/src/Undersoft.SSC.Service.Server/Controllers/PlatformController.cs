using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;
using Undersoft.SSC.Domain.Entities;


namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class PlatformController
        : OpenDataController<long, IEntryStore, IReportStore, Platform, Contracts.Platform>
    {
        public PlatformController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class PlatformsController
        : CrudDataController<long, IEntryStore, IReportStore, Platform, Contracts.Platform>
    {
        public PlatformsController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class PlatformStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Platform, Contracts.Platform>
    {
        public PlatformStreamController() : base() { }
    }
}
