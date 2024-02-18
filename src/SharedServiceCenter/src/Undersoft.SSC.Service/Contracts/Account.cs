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
    public ObjectSet<Role>? Roles { get; set; } = default!;

    [DataMember(Order = 14)]
    public ObjectSet<Claim>? Claims { get; set; } = default!;

    [DataMember(Order = 15)]
    public ObjectSet<Token>? Tokens { get; set; } = default!;

}
