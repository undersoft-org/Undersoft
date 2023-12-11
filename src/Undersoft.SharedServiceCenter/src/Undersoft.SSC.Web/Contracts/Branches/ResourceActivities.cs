using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;


namespace Undersoft.SSC.Web.Contracts.Branches;

public class ResourceActivities : Resource, IContract
{
    public virtual DataObjects<Activity>? Activities { get; set; }
}
