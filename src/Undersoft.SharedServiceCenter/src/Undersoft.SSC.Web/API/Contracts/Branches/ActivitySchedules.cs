using Undersoft.SDK.Service.Data.Contract;


namespace Undersoft.SSC.Web.API.Contracts.Branches;

public class ActivitySchedules : Activity, IContract
{
    public virtual DataObjects<Schedule>? Schedules { get; set; }
}
