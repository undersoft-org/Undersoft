using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Contracts.Details;

namespace Undersoft.SSC.Web.Contracts.Branches;

public class AccountRegistration<TAccount> : ActivityBase, IContract
    where TAccount : class, IDataObject, new()
{
    public virtual DataObjects<TAccount>? Accounts { get; set; } =
        new DataObjects<TAccount>(new TAccount[] { new TAccount() });

    [Detail]
    public virtual RegistrationDetail? Registration { get; set; }

    public virtual TAccount? Account
    {
        get => Accounts?.FirstOrDefault();
        set => Accounts = new DataObjects<TAccount>(new TAccount[] { value ?? new TAccount() });
    }
}
