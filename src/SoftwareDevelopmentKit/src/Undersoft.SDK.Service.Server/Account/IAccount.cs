using System.Security.Claims;
using Undersoft.SDK.Service.Access;

namespace Undersoft.SDK.Service.Server.Accounts
{
    public interface IAccount : IOrigin, IAuthorization
    {
        long UserId { get; set; }

        AccountUser User { get; set; }

        Listing<Role> Roles { get; set; }

        Listing<AccountClaim> Claims { get; set; }

        IEnumerable<Claim> GetClaims();

        long? PersonalId { get; set; }
        AccountPersonal Personal { get; set; }

        long? ProfessionalId { get; set; }
        AccountProfessional Professional { get; set; }

        Listing<AccountOrganization> Organizations { get; set; }

        Listing<AccountConsent> Consents { get; set; }

        Listing<AccountSubscription> Subscriptions { get; set; }

        Listing<AccountPayment> Payments { get; set; }

        bool IsAvailable { get; set; }

        bool Authenticated { get; set; }
    }
}