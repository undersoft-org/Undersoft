using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.Controllers
{
    [AllowAnonymous]
    public class ActivityIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Activity>, Identifier<Contracts.Activity>>
    {
        public ActivityIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Controllers
{
    public class ActivityIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Activity>, Identifier<Contracts.Activity>>
    {
        public ActivityIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Controllers
{
    public class ActivityIdentifierStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Identifier<Activity>, Identifier<Contracts.Activity>>,
            IStreamDataController<Identifier<Contracts.Activity>>
    {
        public ActivityIdentifierStreamController() : base() { }
    }
}
