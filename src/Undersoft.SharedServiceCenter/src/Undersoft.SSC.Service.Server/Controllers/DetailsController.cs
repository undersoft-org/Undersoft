using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;
using Undersoft.SSC.Entities;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class DetailController
        : OpenDataController<long, IEntryStore, IReportStore, Detail, Contracts.Detail>
    {
        public DetailController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class DetailsController
        : CrudDataController<long, IEntryStore, IReportStore, Detail, Contracts.Detail>
    {
        public DetailsController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class DetailStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Detail, Contracts.Detail>
    {
        public DetailStreamController() : base() { }
    }
}
