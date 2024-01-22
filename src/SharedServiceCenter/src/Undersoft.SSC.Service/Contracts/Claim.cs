using System.ComponentModel.DataAnnotations.Schema;
using Undersoft.SDK;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Data.Object.Detail;

namespace Undersoft.SSC.Service.Contracts;

public class Claim : Identifiable
{
        /// <summary>
        /// Gets or sets the claim type for this claim.
        /// </summary>
        public virtual string? ClaimType { get; set; }

        /// <summary>
        /// Gets or sets the claim value for this claim.
        /// </summary>
        public virtual string? ClaimValue { get; set; }
}
