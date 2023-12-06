using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;



namespace Undersoft.SSC.Web.API.Contracts.Branches;

[DataContract]
public class DetailActivities : Detail, IContract
{
    public virtual DataObjects<Activity>? Activities { get; set; }

}
