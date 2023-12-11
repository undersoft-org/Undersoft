using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.Controllers
{
    [AllowAnonymous]
    public class ScheduleController
        : OpenDataController<long, IEntryStore, IReportStore, Schedule, Contracts.Schedule>
    {
        public ScheduleController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Controllers
{
    public class SchedulesController
        : CrudDataController<long, IEntryStore, IReportStore, Schedule, Contracts.Schedule>
    {
        public SchedulesController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Controllers
{
    public class ScheduleStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Schedule, Contracts.Schedule>,
            IStreamDataController<Contracts.Schedule>
    {
        public ScheduleStreamController() : base() { }
    }
}
