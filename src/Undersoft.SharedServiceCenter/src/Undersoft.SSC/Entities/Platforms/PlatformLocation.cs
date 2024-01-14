using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SSC.Entities.Platforms.Locations;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Entities.Platforms
{
    public class PlatformLocation : DataObject
    {
        public virtual string? Name { get; set; }

        public virtual LocaleType LocaleType { get; set; }

        public virtual string? Notices { get; set; }

        public virtual RelatedSet<Endpoint>? Endpoints { get; set; }

        public virtual RelatedSet<Position>? Positions { get; set; }

        public virtual long? PlatformId { get; set; }
        public virtual Platform? Platform { get; set; }
    }
}
