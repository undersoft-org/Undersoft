using Undersoft.SDK.Series;

namespace Undersoft.SDK.Security.Identity;

public class Role : Identifiable
{
    public virtual string Name { get; set; }

    public virtual string NormalizedName { get; set; }

    public Listing<AccountClaim> Claims { get; set; }
}
