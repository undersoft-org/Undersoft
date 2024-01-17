namespace Undersoft.SDK.Service.Server.Account;

public static class AccountServicerExtensions
{
    public static AccountManager GetIdentityManager(this IServicer servicer)
    {
        return servicer.Registry.GetRequiredService<AccountManager>();
    }
}
