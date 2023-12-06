using Undersoft.SDK.Service.Data.Contract;


namespace Undersoft.SSC.Web.API.Contracts.Branches;

public class ResourceSchedules : Resource, IContract
{
    public virtual DataObjects<Schedule>? Schedules { get; set; }
}
