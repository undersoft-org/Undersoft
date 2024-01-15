using Microsoft.AspNetCore.Identity;
using Undersoft.SDK.Uniques;
using System.Security.Claims;

namespace Undersoft.SDK.Service.Application.Account
{
    public interface IAccountClaim<TKey> : IUniqueIdentifiable where TKey : IEquatable<TKey>
    {
        IdentityUserClaim<TKey> Info { get; set; }

        Claim Claim { get; }
    }
}