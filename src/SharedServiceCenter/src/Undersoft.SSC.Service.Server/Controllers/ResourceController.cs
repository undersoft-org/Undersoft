using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;
using Undersoft.SSC.Entities.Resources;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class ResourceController
        : OpenDataController<long, IEntryStore, IReportStore, Resource, Contracts.Resource>
    {
        public ResourceController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class ResourcesController
        : CrudDataController<long, IEntryStore, IReportStore, Resource, Contracts.Resource>
    {
        public ResourcesController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class ResourceStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Resource, Contracts.Resource>
    {
        public ResourceStreamController() : base() { }
    }
}
