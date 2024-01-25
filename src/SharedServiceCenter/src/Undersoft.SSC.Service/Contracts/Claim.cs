using System.ComponentModel.DataAnnotations.Schema;
using Undersoft.SDK;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Data.Object.Detail;

namespace Undersoft.SSC.Service.Contracts;

public class Claim : Identifiable
{
        public virtual string? ClaimType { get; set; }

        public virtual string? ClaimValue { get; set; }
}
