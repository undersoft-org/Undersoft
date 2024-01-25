using Microsoft.AspNetCore.Components.Authorization;
using Undersoft.SDK.Security;

namespace Undersoft.SDK.Service.Application.Services
{
    public interface IAuthenticationStateService
    {
        Task SignIn(IAuthorization authorization);
        Task SignUp(IAuthorization authorization);
        Task SignOut();
    }
}