using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Undersoft.SDK.Service.Server.Account
{
    public interface IAccountRole : IIdentifiable
    {
        Listing<RoleClaim> Claims { get; set; }
    }
}