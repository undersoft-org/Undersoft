using System.ComponentModel.DataAnnotations.Schema;
using Undersoft.SDK;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Data.Object.Detail;

namespace Undersoft.SSC.Service.Contracts;

public class Account : InnerProxy, IDataObject
{
    [NotMapped]
    public Credentials Credentials { get; set; } = new Credentials();

    [NotMapped]
    public AuthorizationNotes Notes { get; set; } = new AuthorizationNotes();
}
