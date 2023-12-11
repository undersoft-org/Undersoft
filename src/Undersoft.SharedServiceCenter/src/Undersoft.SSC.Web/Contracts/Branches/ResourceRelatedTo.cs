using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;


namespace Undersoft.SSC.Web.Contracts.Branches;

public class ResourceRelatedTo : Resource, IContract
{
    public virtual DataObjects<Resource>? RelatedTo { get; set; }
}
