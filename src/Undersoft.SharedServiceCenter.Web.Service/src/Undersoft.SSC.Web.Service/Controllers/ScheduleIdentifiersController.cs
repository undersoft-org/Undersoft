using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.Service.Controllers
{
    [AllowAnonymous]
    public class ScheduleIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Schedule>, Identifier<Contracts.Schedule>>
    {
        public ScheduleIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Service.Controllers
{
    public class ScheduleIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Schedule>, Identifier<Contracts.Schedule>>
    {
        public ScheduleIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

