using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;
using Undersoft.SDK.Service.Infrastructure.Store;

using Undersoft.SSC.Entities;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class ScheduleIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Schedule>, Identifier<Contracts.Schedule>>
    {
        public ScheduleIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class ScheduleIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Schedule>, Identifier<Contracts.Schedule>>
    {
        public ScheduleIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

