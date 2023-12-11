namespace Undersoft.SSC.Web.Contracts.Branches;



using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;

public class ScheduleActivities : Schedule, IContract
{
    public virtual DataObjects<Activity>? Activities { get; set; }
}
