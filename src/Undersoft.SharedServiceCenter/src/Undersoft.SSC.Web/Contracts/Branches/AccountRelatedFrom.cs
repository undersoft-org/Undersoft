using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Contracts.Branches;

[DataContract]
public class AccountRelatedFrom : AccountBase, IContract
{
    public virtual DataObjects<AccountBase>? RelatedFrom { get; set; }

}
