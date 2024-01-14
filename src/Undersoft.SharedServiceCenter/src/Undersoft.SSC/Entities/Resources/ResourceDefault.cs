
using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;

namespace Undersoft.SSC.Entities.Resources
{
    public class ResourceDefault : DataObject, IEntity
    {
        public virtual RelatedSet<Resource>? Resources { get; set; }

        public virtual RelatedSet<ResourceDetail>? Details { get; set; }

        public virtual RelatedSet<ResourceSetting>? Settings { get; set; }
    }
}