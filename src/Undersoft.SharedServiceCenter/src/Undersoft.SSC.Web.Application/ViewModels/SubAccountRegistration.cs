namespace Undersoft.SSC.Web.Application.ViewModels;

public class SubAccountRegistration<TAccount, TSubAccount> : AccountRegistration<AccountModel>
    where TAccount : AccountModel, new() where TSubAccount : AccountModel, new()
{
    public SubAccountRegistration() { Accounts = new DataObjects<AccountModel>(new AccountModel[] { new TAccount(), new TSubAccount() }); }

    public new TAccount? Account
    {
        get => Accounts?.Where(a => a.GetType() == typeof(TAccount)).FirstOrDefault() as TAccount;
        set => (Accounts?.Where(a => a.GetType() == typeof(TAccount)).FirstOrDefault() as TAccount).PatchFrom(value);
    }

    public TSubAccount? SubAccount
    {
        get => Accounts?.Where(a => a.GetType() == typeof(TSubAccount)).FirstOrDefault() as TSubAccount;
        set => (Accounts?.Where(a => a.GetType() == typeof(TSubAccount)).FirstOrDefault() as TSubAccount).PatchFrom(value);
    }
}
