using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Data.Contract;

namespace Undersoft.SDK.Service.Server.Accounts;

public class AccountUser : IdentityUser<long>, IAccountUser
{
    public AccountUser() { Id = Unique.NewId; }
    public AccountUser(string email) : base(email) { Email = email; Id = email.UniqueKey64(); }
    public AccountUser(string userName, string email) : base(userName) { Email = email; Id = email.UniqueKey64(); }

    public long TypeId { get; set; }

    public virtual Account Account { get; set; }
}
