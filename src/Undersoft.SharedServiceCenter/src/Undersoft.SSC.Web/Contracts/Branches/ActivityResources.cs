using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;


namespace Undersoft.SSC.Web.Contracts.Branches;

public class ActivityResources : Activity, IContract
{
    public virtual DataObjects<Resource>? Resources { get; set; }
}
