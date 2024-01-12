using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Entities
{
    public class ActivitySetting : ObjectSetting<ActivitySetting, SettingKind>, IEntity, ISerializableJsonDocument, ISetting
    {
        public virtual RelatedSet<ActivitySetting>? RelatedFrom { get; set; }

        public virtual RelatedSet<ActivitySetting>? RelatedTo { get; set; }

        public virtual RelatedSet<Activity>? Activities { get; set; }

        public virtual long DefaultId { get; set; }
        public virtual ActivityDefault? Default { get; set; }
    }
}