using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.API.Controllers
{
    [AllowAnonymous]
    public class ActivityDataIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Activity>, Identifier<Contracts.Activity>>
    {
        public ActivityDataIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class ActivityIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Activity>, Identifier<Contracts.Activity>>
    {
        public ActivityIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class ActivityIdentifierStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Identifier<Activity>, Identifier<Contracts.Activity>>,
            IStreamDataController<Identifier<Contracts.Activity>>
    {
        public ActivityIdentifierStreamController() : base() { }
    }
}
