using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SDK.Service.Data.Branch;

namespace Undersoft.SSC.Web.API.Controllers
{
    [AllowAnonymous]
    public class EventDataController : OpenEventController<long, IEventStore, Event, EventBranch>
    {
        public EventDataController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class EventsController : CrudEventController<long, IEventStore, Event, EventBranch>
    {
        public EventsController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class EventStreamController
        : StreamEventController<long, IEventStore, Event, EventBranch>,
            IStreamDataController<EventBranch>
    {
        public EventStreamController() : base() { }
    }
}
