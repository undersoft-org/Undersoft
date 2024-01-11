using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;
using Undersoft.SSC.Entities.Schedule;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class ScheduleController
        : OpenDataController<long, IEntryStore, IReportStore, Schedule, Contracts.Schedule>
    {
        public ScheduleController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class SchedulesController
        : CrudDataController<long, IEntryStore, IReportStore, Schedule, Contracts.Schedule>
    {
        public SchedulesController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class ScheduleStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Schedule, Contracts.Schedule>,
            IStreamDataController<Contracts.Schedule>
    {
        public ScheduleStreamController() : base() { }
    }
}
