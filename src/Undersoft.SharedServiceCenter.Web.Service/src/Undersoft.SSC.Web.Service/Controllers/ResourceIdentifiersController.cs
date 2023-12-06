using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.API.Controllers
{
    [AllowAnonymous]
    public class AttachmentDataIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Resource>, Identifier<Contracts.Resource>>
    {
        public AttachmentDataIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class ResourceIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Resource>, Identifier<Contracts.Resource>>
    {
        public ResourceIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class AttachmentIdentifierStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Identifier<Resource>, Identifier<Contracts.Resource>>,
            IStreamDataController<Identifier<Contracts.Resource>>
    {
        public AttachmentIdentifierStreamController() : base() { }
    }
}
