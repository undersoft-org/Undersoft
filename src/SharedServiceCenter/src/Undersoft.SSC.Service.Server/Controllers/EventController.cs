using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;
using Undersoft.SDK.Service.Infrastructure.Store;
using Microsoft.AspNetCore.OData.Routing.Attributes;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataRoute)]
    public class EventController : OpenEventController<long, IEventStore, Event, Event>
    {
        public EventController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class EventsController : ApiEventController<long, IEventStore, Event, Event>
    {
        public EventsController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class EventStreamController : StreamEventController<long, IEventStore, Event, Event>
    {
        public EventStreamController() : base() { }
    }
}
