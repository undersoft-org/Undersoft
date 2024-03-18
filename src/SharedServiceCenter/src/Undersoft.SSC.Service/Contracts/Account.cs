using System.Runtime.Serialization;
using Undersoft.SDK.Service.Access;
using Undersoft.SDK.Service.Data.Contract;

namespace Undersoft.SSC.Service.Contracts;

[DataContract]
public class Account : Authorization, IContract
{
    public Account() { }

    public Account(string email) { Id = email.UniqueKey64(); }

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
    public long? AddressId { get; set; }

    [DataMember(Order = 19)]
    public virtual AccountAddress Address { get; set; } = default!;

    [DataMember(Order = 20)]
    public long? ProfessionalId { get; set; }

    [DataMember(Order = 21)]
    public virtual AccountProfessional Professional { get; set; } = default!;

    [DataMember(Order = 22)]
    public long? OrganizationId { get; set; }

    [DataMember(Order = 23)]
    public virtual AccountOrganization Organization { get; set; } = default!;

    [DataMember(Order = 24)]
    public long? SubscriptionId { get; set; }

    [DataMember(Order = 25)]
    public virtual AccountSubscription Subscription { get; set; } = default!;

    [DataMember(Order = 26)]
    public long? PaymentId { get; set; }

    [DataMember(Order = 27)]
    public virtual AccountPayment Payment { get; set; } = default!;

    [DataMember(Order = 28)]
    public long? ConsentId { get; set; }

    [DataMember(Order = 29)]
    public virtual AccountConsent Consent { get; set; } = default!;
}
