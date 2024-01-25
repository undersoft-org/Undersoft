using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class ServiceController
        : OpenCqrsController<long, IEntryStore, IReportStore, Domain.Entities.Service, Contracts.Service, ServiceManager>
    {
        public ServiceController(IServicer ultimatr) : base(ultimatr) { }
    }


    [Route($"{StoreRoutes.ApiDataRoute}/Service")]
    public class ServicesController
        : ApiCqrsController<long, IEntryStore, IReportStore, Domain.Entities.Service, Contracts.Service, ServiceManager>
    {
        public ServicesController(IServicer ultimatr) : base(ultimatr) { }
    }


    public class ServiceStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Domain.Entities.Service, Contracts.Service>
    {
        public ServiceStreamController() : base() { }
    }
}
