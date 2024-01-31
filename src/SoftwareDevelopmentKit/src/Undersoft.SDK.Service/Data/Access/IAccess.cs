namespace Undersoft.SDK.Security
{
    public interface IAccess
    {
        Task<IAuthorization> SignIn(IAuthorization account);
        Task<IAuthorization> SignOut(IAuthorization account);
        Task<IAuthorization> SignUp(IAuthorization account);
        Task<IAuthorization> Renew(IAuthorization account);
    }
}