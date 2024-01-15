
using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;

namespace Undersoft.SSC.Entities.Members
{
    public class MemberDefault : DataObject, IEntity
    {
        public virtual RelatedSet<Member>? Members { get; set; }

        public virtual RelatedSet<MemberDetail>? Details { get; set; }

        public virtual RelatedSet<MemberSetting>? Settings { get; set; }
    }
}