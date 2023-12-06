namespace Undersoft.SSC.Web.API.Contracts.Branches;


using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Contract;


public class ScheduleLocation : Schedule, IContract
{
    public long? LocationId { get; set; }
    public virtual Location? Location { get; set; }
}
