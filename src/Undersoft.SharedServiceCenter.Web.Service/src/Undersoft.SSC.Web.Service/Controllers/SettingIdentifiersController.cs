using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.API.Controllers
{
    [AllowAnonymous]
    public class DataSettingIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Setting>, Identifier<Contracts.Setting>>
    {
        public DataSettingIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class SettingIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Setting>, Identifier<Contracts.Setting>>
    {
        public SettingIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class SettingIdentifierStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Identifier<Setting>, Identifier<Contracts.Setting>>,
            IStreamDataController<Identifier<Contracts.Setting>>
    {
        public SettingIdentifierStreamController() : base() { }
    }
}
