namespace Undersoft.SDK.Security
{
    public interface IAccountAction
    {
        Task<IAuthorization> ConfirmEmail(IAuthorization account);
        Task<IAuthorization> ResetPassword(IAuthorization account);
        Task<IAuthorization> CompleteRegistration(IAuthorization account);
    }
}