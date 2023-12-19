using Undersoft.SDK.Service.Data.Object.Detail;

namespace Undersoft.SSC.Web.Contracts.Details;

[Detail]
public class LicenceDetail : DataObject
{
    public LicenceDetail() { }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? IssuerName { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? ExpirationDate { get; set; }
}
