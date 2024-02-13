using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using Undersoft.SDK.Service.Access;

namespace Undersoft.SDK.Service.Server.Accounts;

public class Account : Authorization, IEntity, IAccount
{
    public Account() { }

    public Account(string email)
    {
        User = new AccountUser(email);
        Roles = new Listing<Role>();
        Roles.Add(new Role("guest"));
        UserId = User.Id;
    }

    public Account(string email, string role)
    {
        User = new AccountUser(email);
        Roles = new Listing<Role>();
        Roles.Add(new Role(role));
        UserId = User.Id;
    }

    public Account(string userName, string email, IEnumerable<string> roles)
    {
        User = new AccountUser(userName, email);
        Roles = new Listing<Role>();
        roles.ForEach(r => Roles.Add(new Role(r)));
        UserId = User.Id;
    }

    public long UserId { get; set; }
    public virtual AccountUser User { get; set; }

    public virtual Listing<Role> Roles { get; set; }

    [NotMapped]
    public Listing<AccountClaim> Claims { get; set; }

    public virtual Listing<AccountToken> Tokens { get; set; }

    public IEnumerable<Claim> GetClaims()
    {
        return Claims.Select(c => c.Claim);
    }

}
