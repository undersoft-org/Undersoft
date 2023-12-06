namespace Undersoft.SSC.Web.API.Contracts.Branches;



using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Contract;


public class ScheduleResources : Schedule, IContract
{
    public virtual DataObjects<Resource>? Resources { get; set; }
}
