using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;
using Undersoft.SSC.Domain.Entities;


namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class ServiceController
        : OpenDataController<long, IEntryStore, IReportStore, Domain.Entities.Service, Contracts.Service>
    {
        public ServiceController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class ServicesController
        : CrudDataController<long, IEntryStore, IReportStore, Domain.Entities.Service, Contracts.Service>
    {
        public ServicesController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class ServiceStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Domain.Entities.Service, Contracts.Service>
    {
        public ServiceStreamController() : base() { }
    }
}
