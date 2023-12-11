using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.Controllers
{
    [AllowAnonymous]
    public class DetailIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Detail>, Identifier<Contracts.Detail>>
    {
        public DetailIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Controllers
{
    public class DetailIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Detail>, Identifier<Contracts.Detail>>
    {
        public DetailIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Controllers
{
    public class DetailIdentifierStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Identifier<Detail>, Identifier<Contracts.Detail>>,
            IStreamDataController<Identifier<Contracts.Detail>>
    {
        public DetailIdentifierStreamController() : base() { }
    }
}
