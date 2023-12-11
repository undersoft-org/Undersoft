using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;


namespace Undersoft.SSC.Web.Contracts.Branches;

public class ActivitySchedules : Activity, IContract
{
    public virtual DataObjects<Schedule>? Schedules { get; set; }
}
