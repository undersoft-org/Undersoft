using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Undersoft.SDK.Service.Application.Account
{
    public interface IAccountRole<TKey> : IUniqueIdentifiable, IEntity where TKey : IEquatable<TKey>
    {
        IdentityRole<TKey> Info { get; set; }

        Claim Role { get; }

        IEnumerable<IAccountRoleClaim<TKey>> Claims { get; set; }
    }
}