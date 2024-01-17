using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Domain.Entities
{
    public class Setting : ObjectSetting<Setting, SettingKind>, IEntity, ISerializableJsonDocument, ISetting
    {
        public virtual RelatedSet<Setting>? RelatedFrom { get; set; }

        public virtual RelatedSet<Setting>? RelatedTo { get; set; }

        public virtual RelatedSet<Activity>? Activities { get; set; }

        public virtual RelatedSet<Member>? Members { get; set; }

        public virtual RelatedSet<Resource>? Resources { get; set; }

        public virtual RelatedSet<Schedule>? Schedules { get; set; }

        public virtual RelatedSet<Application>? Applications { get; set; }

        public virtual RelatedSet<Platform>? Platforms { get; set; }

        public virtual RelatedSet<Service>? Services { get; set; }

        public virtual RelatedSet<Equipment>? Equipment { get; set; }

        public virtual RelatedSet<Infrastructure>? Infrastructures { get; set; }

        public virtual long DefaultId { get; set; }
        public virtual Default? Default { get; set; }
    }
}