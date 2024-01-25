using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Instant.Updating;
using Undersoft.SDK.Series;

namespace Undersoft.SDK.Security.Identity
{
    [Serializable]
    public class Account : Authorization
    {
        public long UserId { get; set; }
        public AccounUser User { get; set; }

        public Listing<Role> Roles { get; set; }

        public Listing<AccountClaim> Claims { get; set; }

        public Listing<Token> Tokens { get; set; }      
    }
}
