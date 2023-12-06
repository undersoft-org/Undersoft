using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Undersoft.SDK.Service.Data.Contract;

namespace Undersoft.SDK.Service.Application.Account.Identity;

public class AccountIdentity : DataObject, IContract, IAccountIdentity<long>
{
    public IdentityUser<long> Info { get; set; } = new IdentityUser<long>() { Id = Unique.NewId };

    public Registry<AccountIdentityRole<long>> Roles { get; set; }

    public Registry<AccountIdentityClaim<long>> Claims { get; set; }

    public IEnumerable<Claim> GetClaims() { return Claims.Select(c => c.Claim); }

    public AccountIdentityCredentials Credentials { get; set; } = new AccountIdentityCredentials();

    public AccountIdentityNotes Notes { get; set; } = new AccountIdentityNotes();

    public bool IsAuthorized { get; set; }

    public bool IsAuthenticated { get; set; }
}
