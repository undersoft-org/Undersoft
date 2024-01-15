using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Entities.Platforms
{
    public class PlatformSetting : ObjectSetting<PlatformSetting, SettingKind>, IEntity, ISerializableJsonDocument, ISetting
    {
        public virtual RelatedSet<PlatformSetting>? RelatedFrom { get; set; }

        public virtual RelatedSet<PlatformSetting>? RelatedTo { get; set; }

        public virtual RelatedSet<Platform>? Platforms { get; set; }

        public virtual long DefaultId { get; set; }
        public virtual PlatformDefault? Default { get; set; }
    }
}