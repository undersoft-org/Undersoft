using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Entities.Members
{
    public class MemberSetting : ObjectSetting<MemberSetting, SettingKind>, IEntity, ISerializableJsonDocument, ISetting
    {
        public virtual RelatedSet<MemberSetting>? RelatedFrom { get; set; }

        public virtual RelatedSet<MemberSetting>? RelatedTo { get; set; }

        public virtual RelatedSet<Member>? Members { get; set; }

        public virtual long DefaultId { get; set; }
        public virtual MemberDefault? Default { get; set; }
    }
}