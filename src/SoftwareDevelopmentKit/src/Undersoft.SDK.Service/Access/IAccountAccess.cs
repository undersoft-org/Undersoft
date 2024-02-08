namespace Undersoft.SDK.Service.Access
{
    public interface IAccountAccess : IAccountAction, IAccountSetup
    {
        Task<IAuthorization> SignIn(IAuthorization account);
        Task<IAuthorization> SignOut(IAuthorization account);
        Task<IAuthorization> SignUp(IAuthorization account);
        Task<IAuthorization> Renew(IAuthorization account);
        IAuthorization AccountInfo(IAuthorization account);
    }
}