using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities.Activity;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class ActivityController
        : OpenDataController<long, IEntryStore, IReportStore, Activity, Contracts.Activity>
    {
        public ActivityController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class ActivitiesController
        : CrudDataController<long, IEntryStore, IReportStore, Activity, Contracts.Activity>
    {
        public ActivitiesController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class ActivityStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Activity, Contracts.Activity>
    {
        public ActivityStreamController() : base() { }
    }
}
