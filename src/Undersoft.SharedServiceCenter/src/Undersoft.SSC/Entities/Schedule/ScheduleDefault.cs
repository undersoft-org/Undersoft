
using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Relation;

namespace Undersoft.SSC.Entities.Schedule
{
    public class ScheduleDefault : DataObject, IEntity
    {
        public virtual RelatedSet<Schedule>? Schedules { get; set; }

        public virtual RelatedSet<ScheduleDetail>? Details { get; set; }

        public virtual RelatedSet<ScheduleSetting>? Settings { get; set; }
    }
}