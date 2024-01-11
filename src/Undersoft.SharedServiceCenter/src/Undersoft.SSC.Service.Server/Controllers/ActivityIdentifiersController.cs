using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities.Activity;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class ActivityIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Activity>, Identifier<Contracts.Activity>>
    {
        public ActivityIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class ActivityIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Activity>, Identifier<Contracts.Activity>>
    {
        public ActivityIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

