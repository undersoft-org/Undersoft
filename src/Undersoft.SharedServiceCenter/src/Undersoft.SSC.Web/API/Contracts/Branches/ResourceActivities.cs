using Undersoft.SDK.Service.Data.Contract;


namespace Undersoft.SSC.Web.API.Contracts.Branches;

public class ResourceActivities : Resource, IContract
{
    public virtual DataObjects<Activity>? Activities { get; set; }
}
