using Undersoft.SDK.Service.Data.Contract;


namespace Undersoft.SSC.Web.API.Contracts.Branches;

public class ResourceRelatedFrom : Resource, IContract
{
    public virtual DataObjects<Resource>? RelatedFrom { get; set; }
}
