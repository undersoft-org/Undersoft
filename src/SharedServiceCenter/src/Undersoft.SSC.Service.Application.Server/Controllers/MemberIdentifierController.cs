using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SSC.Domain.Entities;
using Undersoft.SSC.Service.Contracts.Base;

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    public class MemberIdentifierController
        : OpenCqrsController<
            long,
            IEntryStore,
            IReportStore,
            Identifier<Member>,
            Identifier<MemberBase>,
            ServiceManager
        >
    {
        public MemberIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }


    public class MemberIdentifiersController
        : ApiCqrsController<
            long,
            IEntryStore,
            IReportStore,
            Identifier<Member>,
            Identifier<MemberBase>,
            ServiceManager
        >
    {
        public MemberIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}
