using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SSC.Entities.Members;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Entities.Platforms;

public class PlatformDetail : ObjectDetail<PlatformDetail, DetailKind>, IEntity, ISerializableJsonDocument, IDetail
{
    public virtual RelatedSet<PlatformDetail>? RelatedFrom { get; set; }

    public virtual RelatedSet<PlatformDetail>? RelatedTo { get; set; }

    public virtual RelatedSet<Platform>? Platforms { get; set; }

    public virtual long DefaultId { get; set; }
    public virtual MemberDefault? Default { get; set; }
}
