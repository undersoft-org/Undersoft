using Undersoft.SDK.Service.Data.Contract;


namespace Undersoft.SSC.Web.API.Contracts.Branches;

public class ActivityLocation : Activity, IContract
{
    public long? LocationId { get; set; }
    public virtual Location? Location { get; set; }
}
