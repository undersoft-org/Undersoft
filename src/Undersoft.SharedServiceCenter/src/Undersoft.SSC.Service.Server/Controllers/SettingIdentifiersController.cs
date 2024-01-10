using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;
using Undersoft.SDK.Service.Infrastructure.Store;

using Undersoft.SSC.Entities;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class SettingIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Setting>, Identifier<Contracts.Setting>>
    {
        public SettingIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class SettingIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Setting>, Identifier<Contracts.Setting>>
    {
        public SettingIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

