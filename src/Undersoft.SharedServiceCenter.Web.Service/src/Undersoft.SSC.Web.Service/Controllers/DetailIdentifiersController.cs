using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.API.Controllers
{
    [AllowAnonymous]
    public class DataDetailIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Detail>, Identifier<Contracts.Detail>>
    {
        public DataDetailIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class DetailIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Detail>, Identifier<Contracts.Detail>>
    {
        public DetailIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class DetailIdentifierStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Identifier<Detail>, Identifier<Contracts.Detail>>,
            IStreamDataController<Identifier<Contracts.Detail>>
    {
        public DetailIdentifierStreamController() : base() { }
    }
}
