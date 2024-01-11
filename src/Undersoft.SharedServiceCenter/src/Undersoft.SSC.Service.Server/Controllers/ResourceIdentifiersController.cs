using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Stream;
using Undersoft.SDK.Service.Server.Controller.Open;

using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities.Resource;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class ResourceIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Resource>, Identifier<Contracts.Resource>>
    {
        public ResourceIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class ResourceIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Resource>, Identifier<Contracts.Resource>>
    {
        public ResourceIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}
