using Undersoft.SDK.Service.Data.Contract;


namespace Undersoft.SSC.Web.API.Contracts.Branches;

public class ActivityAccounts : Activity, IContract
{
    public virtual DataObjects<Account>? Accounts { get; set; }
}
