namespace Undersoft.SSC.Web.API.Contracts.Branches;



using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Contract;


public class ScheduleDefault : Schedule, IContract
{
    public long? DefaultId { get; set; }
    public virtual Default? Default { get; set; }
}
