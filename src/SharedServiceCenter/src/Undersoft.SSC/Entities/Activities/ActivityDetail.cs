using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SSC.Entities.Members;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Entities.Activities;

public class ActivityDetail : ObjectDetail<ActivityDetail, DetailKind>, IEntity, ISerializableJsonDocument, IDetail
{
    public virtual RelatedSet<ActivityDetail>? RelatedFrom { get; set; }

    public virtual RelatedSet<ActivityDetail>? RelatedTo { get; set; }

    public virtual RelatedSet<Activity>? Activities { get; set; }

    public virtual long DefaultId { get; set; }
    public virtual MemberDefault? Default { get; set; }
}
