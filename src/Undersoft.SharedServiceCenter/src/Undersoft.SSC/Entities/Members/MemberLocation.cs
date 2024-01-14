using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SSC.Entities.Members.Locations;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Entities.Members
{
    public class MemberLocation : DataObject
    {
        public virtual string? Name { get; set; }

        public virtual LocaleType LocaleType { get; set; }

        public virtual string? Email { get; set; }

        public virtual PhoneType PhoneType { get; set; }

        public virtual string? PhoneNumber { get; set; }

        public virtual string? Notices { get; set; }

        public virtual RelatedSet<Address>? Addresses { get; set; }

        public virtual RelatedSet<Endpoint>? Endpoints { get; set; }

        public virtual RelatedSet<Position>? Positions { get; set; }

        public virtual long? MemberId { get; set; }
        public virtual Member? Member { get; set; }
    }
}
