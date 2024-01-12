using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Entities.Accounts;

public class AccountDetail : ObjectDetail<AccountDetail, DetailKind>, IEntity, ISerializableJsonDocument, IDetail
{
    public virtual RelatedSet<AccountDetail>? RelatedFrom { get; set; }

    public virtual RelatedSet<AccountDetail>? RelatedTo { get; set; }

    public virtual RelatedSet<Account>? Accounts { get; set; }

    public virtual long DefaultId { get; set; }
    public virtual AccountDefault? Default { get; set; }
}
