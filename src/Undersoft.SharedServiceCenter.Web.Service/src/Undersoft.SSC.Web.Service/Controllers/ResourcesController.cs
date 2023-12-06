using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.API.Controllers
{
    [AllowAnonymous]
    public class ResourceController
        : OpenDataController<long, IEntryStore, IReportStore, Resource, Contracts.Resource>
    {
        public ResourceController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class ResourcesController
        : CrudDataController<long, IEntryStore, IReportStore, Resource, Contracts.Resource>
    {
        public ResourcesController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class ResourceStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Resource, Contracts.Resource>,
            IStreamDataController<Contracts.Resource>
    {
        public ResourceStreamController() : base() { }
    }
}
