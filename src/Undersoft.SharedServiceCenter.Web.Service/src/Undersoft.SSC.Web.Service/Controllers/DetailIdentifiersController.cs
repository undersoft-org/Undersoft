using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.Service.Controllers
{
    [AllowAnonymous]
    public class DetailIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Detail>, Identifier<Web.Contracts.Detail>>
    {
        public DetailIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Service.Controllers
{
    public class DetailIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Detail>, Identifier<Web.Contracts.Detail>>
    {
        public DetailIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

