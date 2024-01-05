using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.Service.Controllers
{
    [AllowAnonymous]
    public class SettingController
        : OpenDataController<long, IEntryStore, IReportStore, Setting, Web.Contracts.Setting>
    {
        public SettingController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Service.Controllers
{
    public class SettingsController
        : CrudDataController<long, IEntryStore, IReportStore, Setting, Web.Contracts.Setting>
    {
        public SettingsController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Service.Controllers
{
    public class SettingStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Setting, Web.Contracts.Setting>,
            IStreamDataController<Web.Contracts.Setting>
    {
        public SettingStreamController() : base() { }
    }
}
