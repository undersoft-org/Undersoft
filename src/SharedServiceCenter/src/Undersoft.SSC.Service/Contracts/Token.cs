using System.ComponentModel.DataAnnotations.Schema;
using Undersoft.SDK;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Data.Object.Detail;

namespace Undersoft.SSC.Service.Contracts;

public class Token : Identifiable
{
    public virtual long UserId { get; set; }

    public virtual string? LoginProvider { get; set; }

    public virtual string? Name { get; set; }

    public virtual string? Value { get; set; }
}