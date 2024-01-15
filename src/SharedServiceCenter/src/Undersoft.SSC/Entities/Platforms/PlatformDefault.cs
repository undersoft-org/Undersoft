
using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;

namespace Undersoft.SSC.Entities.Platforms
{
    public class PlatformDefault : DataObject, IEntity
    {
        public virtual RelatedSet<Platform>? Platforms { get; set; }

        public virtual RelatedSet<PlatformDetail>? Details { get; set; }

        public virtual RelatedSet<PlatformSetting>? Settings { get; set; }
    }
}