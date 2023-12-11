using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;


namespace Undersoft.SSC.Web.Contracts.Branches;

public class ResourceDefault : Resource, IContract
{
    public long? DefaultId { get; set; }
    public virtual Default? Default { get; set; }
}
