using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Entities.Resources
{
    public class ResourceSetting : ObjectSetting<ResourceSetting, SettingKind>, IEntity, ISerializableJsonDocument, ISetting
    {
        public virtual RelatedSet<ResourceSetting>? RelatedFrom { get; set; }

        public virtual RelatedSet<ResourceSetting>? RelatedTo { get; set; }

        public virtual RelatedSet<Resource>? Resources { get; set; }

        public virtual long DefaultId { get; set; }
        public virtual ResourceDefault? Default { get; set; }
    }
}