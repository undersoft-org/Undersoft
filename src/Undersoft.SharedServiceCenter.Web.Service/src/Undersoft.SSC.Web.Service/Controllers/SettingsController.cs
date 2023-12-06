using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.API.Controllers
{
    [AllowAnonymous]
    public class DataSettingController
        : OpenDataController<long, IEntryStore, IReportStore, Setting, Contracts.Setting>
    {
        public DataSettingController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class SettingsController
        : CrudDataController<long, IEntryStore, IReportStore, Setting, Contracts.Setting>
    {
        public SettingsController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class SettingStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Setting, Contracts.Setting>,
            IStreamDataController<Contracts.Setting>
    {
        public SettingStreamController() : base() { }
    }
}
