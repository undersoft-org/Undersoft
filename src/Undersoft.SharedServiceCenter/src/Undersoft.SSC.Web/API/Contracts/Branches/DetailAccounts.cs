using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;



namespace Undersoft.SSC.Web.API.Contracts.Branches;

[DataContract]
public class DetailAccounts : Detail, IContract
{
    public virtual DataObjects<Account>? Accounts { get; set; }

}
