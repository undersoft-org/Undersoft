using System.ComponentModel.DataAnnotations.Schema;

namespace Undersoft.SDK.Security.Identity;

public class AccountClaim : Identifiable
{
    public virtual string ClaimType { get; set; }

    public virtual string ClaimValue { get; set; }
}
