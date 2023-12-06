using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;



namespace Undersoft.SSC.Web.API.Contracts.Branches;

[DataContract]
public class AccountRelatedTo : Account, IContract
{
    public virtual DataObjects<Account>? RelatedTo { get; set; }
}
