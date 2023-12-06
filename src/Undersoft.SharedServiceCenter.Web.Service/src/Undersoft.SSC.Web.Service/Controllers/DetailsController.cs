using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.API.Controllers
{
    [AllowAnonymous]
    public class DataDetailController
        : OpenDataController<long, IEntryStore, IReportStore, Detail, Contracts.Detail>
    {
        public DataDetailController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class DetailsController
        : CrudDataController<long, IEntryStore, IReportStore, Detail, Contracts.Detail>
    {
        public DetailsController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class DetailStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Detail, Contracts.Detail>,
            IStreamDataController<Contracts.Detail>
    {
        public DetailStreamController() : base() { }
    }
}
