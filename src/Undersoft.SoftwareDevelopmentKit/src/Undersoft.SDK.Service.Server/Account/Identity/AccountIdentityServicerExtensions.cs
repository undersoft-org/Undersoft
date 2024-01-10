namespace Undersoft.SDK.Service.Server.Account.Identity;

public static class AccountIdentityServicerExtensions
{
    public static AccountIdentityManager GetIdentity(this IServicer servicer)
    {
        return servicer.Registry.GetRequiredService<AccountIdentityManager>();
    }
}
