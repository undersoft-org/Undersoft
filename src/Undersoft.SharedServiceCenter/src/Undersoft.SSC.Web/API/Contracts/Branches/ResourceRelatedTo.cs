using Undersoft.SDK.Service.Data.Contract;


namespace Undersoft.SSC.Web.API.Contracts.Branches;

public class ResourceRelatedTo : Resource, IContract
{
    public virtual DataObjects<Resource>? RelatedTo { get; set; }
}
