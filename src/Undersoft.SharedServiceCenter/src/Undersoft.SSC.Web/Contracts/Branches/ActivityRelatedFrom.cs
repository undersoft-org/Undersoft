using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Contracts.Branches;

public class ActivityRelatedFrom : Activity, IContract
{
    public virtual DataObjects<Activity>? RelatedFrom { get; set; }
}
