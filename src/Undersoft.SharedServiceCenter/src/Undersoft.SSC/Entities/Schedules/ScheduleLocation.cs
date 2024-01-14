using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SSC.Entities.Schedules.Locations;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Entities.Schedules
{
    public class ScheduleLocation : DataObject
    {
        public virtual string? Name { get; set; }

        public virtual LocaleType LocaleType { get; set; }

        public virtual string? Notices { get; set; }

        public virtual RelatedSet<Position>? Positions { get; set; }

        public virtual RelatedSet<Endpoint>? Endpoints { get; set; }

        public virtual long? ScheduleId { get; set; }
        public virtual Schedule? Schedule { get; set; }
    }
}
