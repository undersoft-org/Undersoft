using Microsoft.AspNetCore.Identity;
using Undersoft.SDK.Uniques;
using System.Security.Claims;
using Undersoft.SDK.Security;
using Undersoft.SDK.Service.Access;

namespace Undersoft.SDK.Service.Server.Accounts
{
    public interface IAccount : IOrigin, IAuthorization
    {
        long UserId { get; set; }

        AccountUser User { get; set; }

        Listing<Role> Roles { get; set; }

        Listing<AccountClaim> Claims { get; set; }

        IEnumerable<Claim> GetClaims();

        bool IsAvailable { get; set; }

        bool Authenticated { get; set; }
    }
}