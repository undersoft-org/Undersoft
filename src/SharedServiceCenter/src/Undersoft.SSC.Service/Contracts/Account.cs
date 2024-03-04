using System.Runtime.Serialization;
using Undersoft.SDK.Service.Access;
using Undersoft.SDK.Service.Data.Contract;

namespace Undersoft.SSC.Service.Contracts;

[DataContract]
public class Account : Authorization, IContract
{
    [DataMember(Order = 12)]
    public AccountUser? User { get; set; } = default!;

    [DataMember(Order = 13)]
    public Listing<Role>? Roles { get; set; } = default!;

    [DataMember(Order = 14)]
    public Listing<Claim>? Claims { get; set; } = default!;

    [DataMember(Order = 15)]
    public Listing<Token>? Tokens { get; set; } = default!;

    [DataMember(Order = 16)]
    public long? PersonalId { get; set; }

    [DataMember(Order = 17)]
    public virtual AccountPersonal Personal { get; set; } = default!;

    [DataMember(Order = 18)]
    public long? ProfessionalId { get; set; }

    [DataMember(Order = 19)]
    public virtual AccountProfessional Professional { get; set; } = default!;

    [DataMember(Order = 20)]
    public virtual Listing<AccountOrganization> Organizations { get; set; } = default!;

    [DataMember(Order = 21)]
    public virtual Listing<AccountConsent> Consents { get; set; } = default!;

    [DataMember(Order = 22)]
    public virtual Listing<AccountSubscription> Subscriptions { get; set; } = default!;

    [DataMember(Order = 23)]
    public virtual Listing<AccountPayment> Payments { get; set; } = default!;
}
