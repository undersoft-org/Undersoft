namespace Undersoft.SSC.Web.API.Contracts.Branches;



using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Contract;


public class ScheduleRelatedFrom : Schedule, IContract
{
    public virtual DataObjects<Schedule>? RelatedFrom { get; set; }
}
