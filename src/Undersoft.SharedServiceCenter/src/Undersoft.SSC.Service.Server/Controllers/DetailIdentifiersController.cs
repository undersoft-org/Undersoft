using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SSC.Entities;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class DetailIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Detail>, Identifier<Contracts.Detail>>
    {
        public DetailIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class DetailIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Detail>, Identifier<Contracts.Detail>>
    {
        public DetailIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

