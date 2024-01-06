using Undersoft.SDK.Security.Identity;

namespace Undersoft.SDK.Blazor.Services
{
    public interface IAuthenticationStateService
    {
        Task SignIn(Authorization userToken);
        Task SignOut();
    }
}