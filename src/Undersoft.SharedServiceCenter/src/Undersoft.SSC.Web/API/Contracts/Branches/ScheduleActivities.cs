namespace Undersoft.SSC.Web.API.Contracts.Branches;



using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Contract;


public class ScheduleActivities : Schedule, IContract
{
    public virtual DataObjects<Activity>? Activities { get; set; }
}
