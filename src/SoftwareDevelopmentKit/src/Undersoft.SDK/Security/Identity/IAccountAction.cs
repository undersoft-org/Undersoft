using Undersoft.SDK.Security.Identity;

namespace Undersoft.SDK.Security.Identity
{
    public interface IAccountAccess
    {
        Task<IAuthorization> CompleteRegistration(IAuthorization account);
        Task<IAuthorization> ConfirmEmail(IAuthorization account);
        Task<IAuthorization> Renew(IAuthorization identity);
        Task<IAuthorization> ResetPassword(IAuthorization account);
        Task<IAuthorization> SignIn(IAuthorization identity);
        Task<IAuthorization> SignOut(IAuthorization identity);
        Task<IAuthorization> SignUp(IAuthorization identity);
    }
}