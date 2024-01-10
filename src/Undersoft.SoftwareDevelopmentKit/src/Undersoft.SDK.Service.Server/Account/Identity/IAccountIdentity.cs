using Microsoft.AspNetCore.Identity;
using Undersoft.SDK.Uniques;
using System.Security.Claims;
using Undersoft.SDK.Security.Identity;

namespace Undersoft.SDK.Service.Server.Account.Identity
{
    public interface IAccountIdentity<TKey> : IOrigin where TKey : IEquatable<TKey>
    {
        IdentityUser<TKey> Info { get; set; }

        Registry<AccountIdentityRole<TKey>> Roles { get; set; }

        Registry<AccountIdentityClaim<TKey>> Claims { get; set; }

        IEnumerable<Claim> GetClaims();

        Credentials Credentials { get; set; }

        AuthorizationNotes Notes { get; set; }

        bool Authorized { get; set; }

        bool Authenticated { get; set; }
    }
}
