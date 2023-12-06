using Undersoft.SDK.Service.Data.Contract;



namespace Undersoft.SSC.Web.API.Contracts.Branches;

public class ActivityRelatedFrom : Activity, IContract
{
    public virtual DataObjects<Activity>? RelatedFrom { get; set; }
}
