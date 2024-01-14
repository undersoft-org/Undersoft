using Microsoft.AspNetCore.Identity;
using Undersoft.SDK.Uniques;
using System.Security.Claims;
using Undersoft.SDK.Security.Identity;

namespace Undersoft.SDK.Service.Application.Account
{
    public interface IAccount<TKey> : IOrigin where TKey : IEquatable<TKey>
    {
        IdentityUser<TKey> Info { get; set; }

        Registry<AccountRole<TKey>> Roles { get; set; }

        Registry<AccountClaim<TKey>> Claims { get; set; }

        IEnumerable<Claim> GetClaims();

        Credentials Credentials { get; set; }

        AuthorizationNotes Notes { get; set; }

        bool Authorized { get; set; }

        bool Authenticated { get; set; }
    }
}
