using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.Controllers
{
    [AllowAnonymous]
    public class SettingController
        : OpenDataController<long, IEntryStore, IReportStore, Setting, Contracts.Setting>
    {
        public SettingController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Controllers
{
    public class SettingsController
        : CrudDataController<long, IEntryStore, IReportStore, Setting, Contracts.Setting>
    {
        public SettingsController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Controllers
{
    public class SettingStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Setting, Contracts.Setting>,
            IStreamDataController<Contracts.Setting>
    {
        public SettingStreamController() : base() { }
    }
}
