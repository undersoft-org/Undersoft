using System.ComponentModel.DataAnnotations.Schema;
using Undersoft.SDK;
using Undersoft.SDK.Security;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SDK.Service.Data.Object.Detail;

namespace Undersoft.SSC.Service.Contracts;

public class Account : InnerProxy, IDataObject, IContract, IAuthorization
{
    public AccounUser? User { get; set; }

    public Listing<Role>? Roles { get; set; }

    public Listing<Claim>? Claims { get; set; }

    public Listing<Token>? Tokens { get; set; }

    public Credentials Credentials { get; set; } = new Credentials();

    public AuthorizationNotes Notes { get; set; } = new AuthorizationNotes();
}
