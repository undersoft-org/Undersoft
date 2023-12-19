using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Contracts.Details;
using Undersoft.SSC.Web.Enums;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class AccountRegistration<TAccount> : ViewModelBase<ActivityBase, Detail, Setting, ActivityGroup>, IViewModel
    where TAccount : AccountModel, new()
{
    public AccountRegistration() : base() { Accounts = new DataObjects<TAccount>(new TAccount[] { new TAccount() }); }

    public virtual DataObjects<TAccount>? Accounts { get; set; } 

    [Detail]
    public virtual RegistrationDetail? Registration { get; set; }

    public virtual TAccount? Account
    {
        get => Accounts?.Where(a => a.GetType() == typeof(TAccount)).FirstOrDefault() as TAccount;
        set => Accounts = new DataObjects<TAccount>(new TAccount[] { value ?? new TAccount() });
    }
}
