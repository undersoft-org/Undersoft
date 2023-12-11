namespace Undersoft.SSC.Web.Contracts.Branches;


using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;

public class ScheduleLocation : Schedule, IContract
{
    public long? LocationId { get; set; }
    public virtual Location? Location { get; set; }
}
