namespace Undersoft.SSC.Web.Contracts.Branches;



using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;

public class ScheduleRelatedTo : Schedule, IContract
{
    public virtual DataObjects<Schedule>? RelatedTo { get; set; }
}
