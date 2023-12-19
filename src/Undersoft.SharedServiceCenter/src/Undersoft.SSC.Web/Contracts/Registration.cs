using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Web.Contracts.Details;

namespace Undersoft.SSC.Web.Contracts;

public class Registration : ActivityBase, IContract
{
    public virtual DataObjects<Account>? Accounts { get; set; }
}
