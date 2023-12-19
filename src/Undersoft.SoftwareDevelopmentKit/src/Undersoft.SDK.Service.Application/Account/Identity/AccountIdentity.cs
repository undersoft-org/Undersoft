using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Data.Contract;

namespace Undersoft.SDK.Service.Application.Account.Identity;

public class AccountIdentity : DataObject, IContract, IAccountIdentity<long>
{
    public IdentityUser<long> Info { get; set; } = new IdentityUser<long>() { Id = Unique.NewId };

    public Registry<AccountIdentityRole<long>> Roles { get; set; }

    public Registry<AccountIdentityClaim<long>> Claims { get; set; }

    public IEnumerable<Claim> GetClaims() { return Claims.Select(c => c.Claim); }

    public ICredentials Credentials { get; set; } = new Credentials();

    public AuthorizationNotes Notes { get; set; } = new AuthorizationNotes();

    public bool Authorized { get; set; }

    public bool Authenticated { get; set; }
}
