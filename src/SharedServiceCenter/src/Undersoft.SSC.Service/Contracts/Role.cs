using System.ComponentModel.DataAnnotations.Schema;
using Undersoft.SDK;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Data.Object.Detail;

namespace Undersoft.SSC.Service.Contracts;

public class Role : Identifiable 
{ 
    public virtual string? Name { get; set; }

    public virtual string? NormalizedName { get; set; }

    public Listing<Claim>? Claims { get; set; }
}
