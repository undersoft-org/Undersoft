using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Contracts.Branches;

[DataContract]
public class AccountRelatedTo : AccountBase, IContract
{
    public virtual DataObjects<AccountBase>? RelatedTo { get; set; }
}
