using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Web.API.Contracts.Details;

public class LicenceDetail : DataObject
{
    public LicenceDetail() { }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? IssuerName { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? ExpirationDate { get; set; }
}
