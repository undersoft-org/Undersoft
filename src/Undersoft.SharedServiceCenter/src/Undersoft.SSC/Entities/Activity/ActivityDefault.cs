
using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Relation;
using Undersoft.SSC.Entities.Activities;

namespace Undersoft.SSC.Entities
{
    public class ActivityDefault : DataObject, IEntity
    {
        public virtual RelatedSet<Activity>? Activities { get; set; }

        public virtual RelatedSet<ActivityDetail>? Details { get; set; }

        public virtual RelatedSet<ActivitySetting>? Settings { get; set; }
    }
}