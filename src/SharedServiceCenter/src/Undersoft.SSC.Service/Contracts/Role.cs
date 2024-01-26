using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Undersoft.SDK;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Data.Object.Detail;

namespace Undersoft.SSC.Service.Contracts;

[DataContract]
public class Role : Identifiable 
{
    [DataMember(Order = 6)]
    public virtual string? Name { get; set; }

    [DataMember(Order = 7)]
    public virtual string? NormalizedName { get; set; }

    [DataMember(Order = 8)]
    public Listing<Claim>? Claims { get; set; }
}
