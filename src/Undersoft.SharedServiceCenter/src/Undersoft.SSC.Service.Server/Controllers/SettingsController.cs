using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class SettingController
        : OpenDataController<long, IEntryStore, IReportStore, Setting, Contracts.Setting>
    {
        public SettingController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class SettingsController
        : CrudDataController<long, IEntryStore, IReportStore, Setting, Contracts.Setting>
    {
        public SettingsController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class SettingStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Setting, Contracts.Setting>,
            IStreamDataController<Contracts.Setting>
    {
        public SettingStreamController() : base() { }
    }
}
