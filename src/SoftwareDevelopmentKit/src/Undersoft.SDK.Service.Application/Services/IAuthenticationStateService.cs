using Undersoft.SDK.Security.Identity;

namespace Undersoft.SDK.Service.Application.Services
{
    public interface IAuthenticationStateService
    {
        Task SignIn(Authorization userToken);
        Task SignOut();
    }
}