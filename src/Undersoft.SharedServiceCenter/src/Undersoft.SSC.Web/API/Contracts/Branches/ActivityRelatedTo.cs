using Undersoft.SDK.Service.Data.Contract;



namespace Undersoft.SSC.Web.API.Contracts.Branches;

public class ActivityRelatedTo : Activity, IContract
{
    public virtual DataObjects<Activity>? RelatedTo { get; set; }
}
