using Undersoft.SDK.Service.Data.Relation;
using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Entities.Locations;

namespace Undersoft.SSC.Entities.Schedules
{
    public class ScheduleLocation : DataObject
    {
        public virtual string? Name { get; set; }

        public virtual LocaleType LocaleType { get; set; }

        public virtual string? Email { get; set; }

        public virtual PhoneType PhoneType { get; set; }

        public virtual string? PhoneNumber { get; set; }

        public virtual string? Notices { get; set; }

        public virtual RelatedSet<Address>? Addresses { get; set; }

        public virtual RelatedSet<Endpoint>? Endpoints { get; set; }

        public virtual long? ScheduleId { get; set; }
        public virtual Schedule? Schedule { get; set; }
    }
}
