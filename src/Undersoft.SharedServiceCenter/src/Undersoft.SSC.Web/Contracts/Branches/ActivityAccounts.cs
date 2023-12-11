using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;


namespace Undersoft.SSC.Web.Contracts.Branches;

public class ActivityAccounts : Activity, IContract
{
    public virtual DataObjects<AccountBase>? Accounts { get; set; }
}
