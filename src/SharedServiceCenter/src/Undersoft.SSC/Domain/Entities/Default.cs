
using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;

namespace Undersoft.SSC.Domain.Entities
{
    public class Default : DataObject, IEntity
    {
        public virtual RelatedSet<Activity>? Activities { get; set; }

        public virtual RelatedSet<Member>? Members { get; set; }

        public virtual RelatedSet<Resource>? Resources { get; set; }

        public virtual RelatedSet<Schedule>? Schedules { get; set; }

        public virtual RelatedSet<Platform>? Platforms { get; set; }

        public virtual RelatedSet<Application>? Applications { get; set; }

        public virtual RelatedSet<Service>? Services { get; set; }

        public virtual RelatedSet<Equipment>? Equipment { get; set; }

        public virtual RelatedSet<Infrastructure>? Infrastructures { get; set; }

        public virtual RelatedSet<Detail>? Details { get; set; }

        public virtual RelatedSet<Setting>? Settings { get; set; }
    }
}