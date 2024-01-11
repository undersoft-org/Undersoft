
using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Relation;

namespace Undersoft.SSC.Entities.Activity
{
    public class ActivityDefault : DataObject, IEntity
    {
        public virtual RelatedSet<Activity>? Activitys { get; set; }

        public virtual RelatedSet<ActivityDetail>? Details { get; set; }

        public virtual RelatedSet<ActivitySetting>? Settings { get; set; }
    }
}