using Microsoft.AspNetCore.Identity;
using Undersoft.SDK.Uniques;
using System.Security.Claims;

namespace Undersoft.SDK.Service.Server.Account.Identity
{
    public interface IAccountIdentityRoleClaim<TKey> : IUniqueIdentifiable where TKey : IEquatable<TKey>
    {
        IdentityRoleClaim<TKey> Info { get; set; }

        Claim Claim { get; }
    }
}