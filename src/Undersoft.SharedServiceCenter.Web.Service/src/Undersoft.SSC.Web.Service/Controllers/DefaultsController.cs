using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.Service.Controllers
{
    [AllowAnonymous]
    public class DefaultDataController
        : OpenDataController<long, IEntryStore, IReportStore, Default, Web.Contracts.Default>
    {
        public DefaultDataController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Service.Controllers
{
    public class DefaultsController
        : CrudDataController<long, IEntryStore, IReportStore, Default, Web.Contracts.Default>
    {
        public DefaultsController(IServicer ultimatr) : base(ultimatr) { }
    }
}
