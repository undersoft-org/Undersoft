using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Entities.Members;

public class MemberDetail : ObjectDetail<MemberDetail, DetailKind>, IEntity, ISerializableJsonDocument, IDetail
{
    public virtual RelatedSet<MemberDetail>? RelatedFrom { get; set; }

    public virtual RelatedSet<MemberDetail>? RelatedTo { get; set; }

    public virtual RelatedSet<Member>? Members { get; set; }

    public virtual long DefaultId { get; set; }
    public virtual MemberDefault? Default { get; set; }
}
