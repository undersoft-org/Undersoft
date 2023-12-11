using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Contracts.Branches;

[DataContract]
public class DetailActivities : Detail, IContract
{
    public virtual DataObjects<Activity>? Activities { get; set; }

}
