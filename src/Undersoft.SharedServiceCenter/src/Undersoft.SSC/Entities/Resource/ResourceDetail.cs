using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Entities.Resources;

public class ResourceDetail : ObjectDetail<ResourceDetail, DetailKind>, IEntity, ISerializableJsonDocument, IDetail
{
    public virtual RelatedSet<ResourceDetail>? RelatedFrom { get; set; }

    public virtual RelatedSet<ResourceDetail>? RelatedTo { get; set; }

    public virtual RelatedSet<Resource>? Resources { get; set; }

    public virtual long DefaultId { get; set; }
    public virtual ResourceDefault? Default { get; set; }
}
