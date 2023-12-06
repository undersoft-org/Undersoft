namespace Undersoft.SSC.Web.API.Contracts.Branches;



using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Contract;


public class ScheduleAccounts : Schedule, IContract
{
    public virtual DataObjects<Account>? Accounts { get; set; }
}
