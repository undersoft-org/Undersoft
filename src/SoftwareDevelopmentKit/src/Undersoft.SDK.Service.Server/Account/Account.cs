﻿using System.ComponentModel.DataAnnotations.Schema;
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

    public long? PersonalId
    {
        get; set;
    }
    public virtual AccountPersonal Personal { get; set; }

    public virtual Listing<AccountProffesional> Proffesionals { get; set; }

    public virtual Listing<AccountOrganization> Organizations { get; set; }

    public virtual Listing<AccountConsent> Consents { get; set; }

    public virtual Listing<AccountSubscription> Subscriptions { get; set; }

    public virtual Listing<AccountPayment> Payments { get; set; }

    public IEnumerable<Claim> GetClaims()
    {
        return Claims.Select(c => c.Claim);
    }

}
