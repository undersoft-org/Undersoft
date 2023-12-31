﻿using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.Service.Controllers
{
    [AllowAnonymous]
    public class ResourceIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Resource>, Identifier<Contracts.Resource>>
    {
        public ResourceIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Service.Controllers
{
    public class ResourceIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Resource>, Identifier<Contracts.Resource>>
    {
        public ResourceIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}
