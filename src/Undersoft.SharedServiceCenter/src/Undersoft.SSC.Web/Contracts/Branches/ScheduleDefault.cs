namespace Undersoft.SSC.Web.Contracts.Branches;



using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;

public class ScheduleDefault : Schedule, IContract
{
    public long? DefaultId { get; set; }
    public virtual Default? Default { get; set; }
}
