using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;



namespace Undersoft.SSC.Web.API.Contracts.Branches;

[DataContract]
public class AccountActivities : Account, IContract
{
    public virtual DataObjects<Activity>? Activities { get; set; }
}
