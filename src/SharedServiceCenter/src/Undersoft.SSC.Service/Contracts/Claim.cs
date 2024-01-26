using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Undersoft.SDK;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Data.Object.Detail;

namespace Undersoft.SSC.Service.Contracts;

[DataContract]
public class Claim : Identifiable
{
    [DataMember(Order = 6)]
    public virtual string? ClaimType { get; set; }

    [DataMember(Order = 7)]
    public virtual string? ClaimValue { get; set; }
}
