using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Entities.Account;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Entities.Activity;

public class ActivityDetail : ObjectDetail<ActivityDetail, DetailKind>, IEntity, ISerializableJsonDocument, IDetail
{
    public virtual RelatedSet<ActivityDetail>? RelatedFrom { get; set; }

    public virtual RelatedSet<ActivityDetail>? RelatedTo { get; set; }

    public virtual RelatedSet<Activity>? Activities { get; set; }

    public virtual long DefaultId { get; set; }
    public virtual AccountDefault? Default { get; set; }
}
