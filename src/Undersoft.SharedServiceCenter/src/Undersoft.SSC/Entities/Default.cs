
using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Relation;

namespace Undersoft.SSC.Entities
{
    public class Default : DataObject, IEntity
    {
        public virtual RelatedSet<Account>? Accounts { get; set; }

        public virtual RelatedSet<Activity>? Activities { get; set; }

        public virtual RelatedSet<Resource>? Resources { get; set; }

        public virtual RelatedSet<Schedule>? Schedules { get; set; }

        public virtual RelatedSet<Detail>? Details { get; set; }

        public virtual RelatedSet<Setting>? Settings { get; set; }
    }
}