using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Data.Contract;

namespace Undersoft.SDK.Service.Application.Account;

public class Account : DataObject, IContract, IAccount<long>, IAuthorization
{
    public IdentityUser<long> Info { get; set; } = new IdentityUser<long>() { Id = Unique.NewId };

    public Registry<AccountRole<long>> Roles { get; set; }

    public Registry<AccountClaim<long>> Claims { get; set; }

    public IEnumerable<Claim> GetClaims() { return Claims.Select(c => c.Claim); }

    public Credentials Credentials { get; set; } = new Credentials();

    public AuthorizationNotes Notes { get; set; } = new AuthorizationNotes();

    public bool Authorized { get; set; }

    public bool Authenticated { get; set; }
}
