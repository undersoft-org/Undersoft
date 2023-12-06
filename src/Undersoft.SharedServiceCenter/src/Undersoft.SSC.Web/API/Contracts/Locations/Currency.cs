namespace Undersoft.SSC.Web.API.Contracts.Locations;

public partial class Currency : DataObject
{
    public string? Name { get; set; }

    public string? CurrencyCode { get; set; }

    public double Rate { get; set; }
}
