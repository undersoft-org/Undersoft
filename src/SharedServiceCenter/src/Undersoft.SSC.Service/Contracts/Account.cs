using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Undersoft.SDK;
using Undersoft.SDK.Security;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SDK.Service.Data.Object.Detail;

namespace Undersoft.SSC.Service.Contracts;

[DataContract]
public class Account : InnerProxy, IDataObject, IContract, IAuthorization
{
    [DataMember(Order = 12)]
    public AccounUser? User { get; set; }

    [DataMember(Order = 13)]
    public Listing<Role>? Roles { get; set; }

    [DataMember(Order = 14)]
    public Listing<Claim>? Claims { get; set; }

    [DataMember(Order = 15)]
    public Listing<Token>? Tokens { get; set; }

    [DataMember(Order = 16)]
    public Credentials Credentials { get; set; } = new Credentials();

    [DataMember(Order = 17)]
    public AuthorizationNotes Notes { get; set; } = new AuthorizationNotes();
}
