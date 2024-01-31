namespace Undersoft.SDK.Security
{
    public interface IAccountAction : IAccountAccess
    {
        Task<IAuthorization> CompleteRegistration(IAuthorization account);
        Task<IAuthorization> ConfirmEmail(IAuthorization account);
        Task<IAuthorization> ResetPassword(IAuthorization account);
    }
}