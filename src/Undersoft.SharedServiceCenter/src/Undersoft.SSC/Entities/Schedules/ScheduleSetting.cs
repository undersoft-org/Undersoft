using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Entities.Schedules
{
    public class ScheduleSetting : ObjectSetting<ScheduleSetting, SettingKind>, IEntity, ISerializableJsonDocument, ISetting
    {
        public virtual RelatedSet<ScheduleSetting>? RelatedFrom { get; set; }

        public virtual RelatedSet<ScheduleSetting>? RelatedTo { get; set; }

        public virtual RelatedSet<Schedule>? Schedules { get; set; }

        public virtual long DefaultId { get; set; }
        public virtual ScheduleDefault? Default { get; set; }
    }
}