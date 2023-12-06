namespace Undersoft.SSC.Web.API.Contracts.Branches;



using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Contract;


public class ScheduleRelatedTo : Schedule, IContract
{
    public virtual DataObjects<Schedule>? RelatedTo { get; set; }
}
