using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class InfrastructureController
        : OpenDataController<long, IEntryStore, IReportStore, Undersoft.SSC.Domain.Entities.Infrastructure, Undersoft.SSC.Service.Contracts.Infrastructure>
    {
        public InfrastructureController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class InfrastructuresController
        : CrudDataController<long, IEntryStore, IReportStore, Undersoft.SSC.Domain.Entities.Infrastructure, Undersoft.SSC.Service.Contracts.Infrastructure>
    {
        public InfrastructuresController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class InfrastructureStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Undersoft.SSC.Domain.Entities.Infrastructure, Undersoft.SSC.Service.Contracts.Infrastructure>
    {
        public InfrastructureStreamController() : base() { }
    }
}
