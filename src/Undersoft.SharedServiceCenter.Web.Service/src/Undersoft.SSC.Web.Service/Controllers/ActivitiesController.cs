using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.Controllers
{
    [AllowAnonymous]
    public class ActivityController
        : OpenDataController<long, IEntryStore, IReportStore, Activity, Contracts.Activity>
    {
        public ActivityController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Controllers
{
    public class ActivitiesController
        : CrudDataController<long, IEntryStore, IReportStore, Activity, Contracts.Activity>
    {
        public ActivitiesController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Controllers
{
    public class ActivityStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Activity, Contracts.Activity>,
            IStreamDataController<Contracts.Activity>
    {
        public ActivityStreamController() : base() { }
    }
}
