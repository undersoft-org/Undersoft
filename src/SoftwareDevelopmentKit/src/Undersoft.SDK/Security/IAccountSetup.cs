namespace Undersoft.SDK.Security
{
    public interface IAccountSetup
    {
        Task<IAuthorization> ChangePassword(IAuthorization account);
    }
}