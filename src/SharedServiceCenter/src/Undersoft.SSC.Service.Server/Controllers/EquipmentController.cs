using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;
using Undersoft.SSC.Domain.Entities;


namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class EquipmentController
        : OpenDataController<long, IEntryStore, IReportStore, Equipment, Contracts.Equipment>
    {
        public EquipmentController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class EquipmentsController
        : CrudDataController<long, IEntryStore, IReportStore, Equipment, Contracts.Equipment>
    {
        public EquipmentsController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class EquipmentStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Equipment, Contracts.Equipment>
    {
        public EquipmentStreamController() : base() { }
    }
}
