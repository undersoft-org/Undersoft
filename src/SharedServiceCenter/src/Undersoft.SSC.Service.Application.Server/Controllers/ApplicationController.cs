using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Service.Application.Models;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataRoute)]
    public class ApplicationController : OpenDataController<long, IEntryStore, IReportStore, Contracts.Application, Contracts.Application>
    {
        public ApplicationController(IServicer ultimatr)
            : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    public class ApplicationsController : CrudDataController<long, IEntryStore, IReportStore, Contracts.Application, Contracts.Application>
    {
        public ApplicationsController(IServicer ultimatr)
            : base(ultimatr) { }
    }
}
