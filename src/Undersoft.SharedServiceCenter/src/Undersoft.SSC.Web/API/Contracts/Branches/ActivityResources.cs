using Undersoft.SDK.Service.Data.Contract;


namespace Undersoft.SSC.Web.API.Contracts.Branches;

public class ActivityResources : Activity, IContract
{
    public virtual DataObjects<Resource>? Resources { get; set; }
}
