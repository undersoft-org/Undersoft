using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Entities
{
    public class Setting : ObjectSetting<Setting, SettingKind>, IEntity, ISerializableJsonDocument, ISetting
    {
        public virtual RelatedSet<Setting>? RelatedFrom { get; set; }

        public virtual RelatedSet<Setting>? RelatedTo { get; set; }

        public virtual RelatedSet<Account>? Accounts { get; set; }

        public virtual RelatedSet<Activity>? Activities { get; set; }

        public virtual RelatedSet<Schedule>? Schedules { get; set; }

        public virtual RelatedSet<Resource>? Resources { get; set; }

        public virtual long DefaultId { get; set; }
        public virtual Default? Default { get; set; }
    }
}