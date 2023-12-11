using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;


namespace Undersoft.SSC.Web.Contracts.Branches;

public class ActivityLocation : Activity, IContract
{
    public long? LocationId { get; set; }
    public virtual Location? Location { get; set; }
}
