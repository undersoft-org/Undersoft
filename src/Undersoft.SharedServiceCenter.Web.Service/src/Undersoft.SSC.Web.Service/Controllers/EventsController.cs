﻿using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;

namespace Undersoft.SSC.Web.Service.Controllers
{
    [AllowAnonymous]
    public class EventController : OpenEventController<long, IEventStore, Event, Event>
    {
        public EventController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Service.Controllers
{
    public class EventsController : CrudEventController<long, IEventStore, Event, Event>
    {
        public EventsController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Service.Controllers
{
    public class EventStreamController
        : StreamEventController<long, IEventStore, Event, Event>
    {
        public EventStreamController() : base() { }
    }
}
