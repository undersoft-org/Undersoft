using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.API.Controllers
{
    [AllowAnonymous]
    public class ScheduleDataIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Schedule>, Identifier<Contracts.Schedule>>
    {
        public ScheduleDataIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class ScheduleIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Schedule>, Identifier<Contracts.Schedule>>
    {
        public ScheduleIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class ScheduleIdentifierStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Identifier<Schedule>, Identifier<Contracts.Schedule>>,
            IStreamDataController<Identifier<Contracts.Schedule>>
    {
        public ScheduleIdentifierStreamController() : base() { }
    }
}
