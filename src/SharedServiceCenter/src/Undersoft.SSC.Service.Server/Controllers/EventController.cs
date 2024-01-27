using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    [ApiVersion("OPEN")]
    public class EventController : OpenEventController<long, IEventStore, Event, Event>
    {
        public EventController(IServicer ultimatr) : base(ultimatr) { }
    }

    [ApiVersion("REST")]
    [Route($"{StoreRoutes.ApiEventRoute}/Event")]
    public class EventsController : ApiEventController<long, IEventStore, Event, Event>
    {
        public EventsController(IServicer ultimatr) : base(ultimatr) { }
    }

    [ApiVersion("GRPC")]
    public class EventStreamController : StreamEventController<long, IEventStore, Event, Event>
    {
        public EventStreamController() : base() { }
    }
}
