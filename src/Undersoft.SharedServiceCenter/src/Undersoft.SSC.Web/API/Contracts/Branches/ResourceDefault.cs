using Undersoft.SDK.Service.Data.Contract;


namespace Undersoft.SSC.Web.API.Contracts.Branches;

public class ResourceDefault : Resource, IContract
{
    public long? DefaultId { get; set; }
    public virtual Default? Default { get; set; }
}
