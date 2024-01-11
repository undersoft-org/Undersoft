
using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Relation;

namespace Undersoft.SSC.Entities.Resource
{
    public class ResourceDefault : DataObject, IEntity
    {
        public virtual RelatedSet<Resource>? Resources { get; set; }

        public virtual RelatedSet<ResourceDetail>? Details { get; set; }

        public virtual RelatedSet<ResourceSetting>? Settings { get; set; }
    }
}