using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.Service.Controllers
{
    [AllowAnonymous]
    public class SettingIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Setting>, Identifier<Web.Contracts.Setting>>
    {
        public SettingIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Service.Controllers
{
    public class SettingIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Setting>, Identifier<Web.Contracts.Setting>>
    {
        public SettingIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

