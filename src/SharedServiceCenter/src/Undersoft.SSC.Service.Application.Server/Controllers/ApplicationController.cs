using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    public class ApplicationController
        : OpenCqrsController<
            long,
            IEntryStore,
            IReportStore,
            Domain.Entities.Application,
            Contracts.Application, ServiceManager
        >
    {
        public ApplicationController(IServicer ultimatr) : base(ultimatr) { }
    }


    public class ApplicationsController
        : ApiCqrsController<
            long,
            IEntryStore,
            IReportStore,
            Domain.Entities.Application,
            Contracts.Application, ServiceManager
        >
    {
        public ApplicationsController(IServicer ultimatr) : base(ultimatr) { }
    }
}
