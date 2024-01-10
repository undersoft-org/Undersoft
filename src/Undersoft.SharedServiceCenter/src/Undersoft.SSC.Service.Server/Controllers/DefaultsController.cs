using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;
using Undersoft.SDK.Service.Infrastructure.Store;

using Undersoft.SSC.Entities;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class DefaultDataController
        : OpenDataController<long, IEntryStore, IReportStore, Default, Contracts.Default>
    {
        public DefaultDataController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class DefaultsController
        : CrudDataController<long, IEntryStore, IReportStore, Default, Contracts.Default>
    {
        public DefaultsController(IServicer ultimatr) : base(ultimatr) { }
    }
}
