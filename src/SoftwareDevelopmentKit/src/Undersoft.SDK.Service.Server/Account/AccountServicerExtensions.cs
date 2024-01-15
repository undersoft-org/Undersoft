namespace Undersoft.SDK.Service.Application.Account;

public static class AccountServicerExtensions
{
    public static AccountManager GetIdentityManager(this IServicer servicer)
    {
        return servicer.Registry.GetRequiredService<AccountManager>();
    }
}
