using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Web.Contracts.Locations;

namespace Undersoft.SSC.Web.Contracts.Details;

[Detail]
public class AmountDetail : DataObject
{
    public AmountDetail() { }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string TypeName { get; set; }

    public long CurrencyId { get; set; }
    public virtual Currency Currency { get; set; }

    public double GrossAmount { get; set; }
    public double TaxAmount { get; set; }
    public double NetAmount { get; set; }

    public double GrossShare { get; set; }
    public double TaxShare { get; set; }
    public double NetShare { get; set; }
}
