using Undersoft.SDK.Service.Data.Contract;


namespace Undersoft.SSC.Web.API.Contracts.Branches;

public class ActivityDefault : Activity, IContract
{
    public long? DefaultId { get; set; }
    public virtual Default? Default { get; set; }
}
