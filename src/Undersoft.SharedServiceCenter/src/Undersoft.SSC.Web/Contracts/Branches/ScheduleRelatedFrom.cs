namespace Undersoft.SSC.Web.Contracts.Branches;



using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;

public class ScheduleRelatedFrom : Schedule, IContract
{
    public virtual DataObjects<Schedule>? RelatedFrom { get; set; }
}
