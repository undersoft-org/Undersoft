using Google.Protobuf.WellKnownTypes;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Web.Contracts.Locations;

namespace Undersoft.SSC.Web.Contracts.Details;

[Detail]
public class AmountDetail : DataObject
{
    public AmountDetail() { }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public AmountKind? Kind { get; set; }

    public long CurrencyId { get; set; }
    public virtual Currency? Currency { get; set; }

    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public DateTime Deadline { get; set; }
    public TimeSpan Interval { get; set; }
    public double Duration { get; set; }

    public double Quantity { get; set; }

    public double Value { get; set; }
    public double Tax { get; set; }
    public double TaxValue { get; set; }
    public double NetValue { get; set; }

    public double Fraction { get; set; }
    public double Factor { get; set; }
    public double Bias { get; set; } 

    public double Amount { get; set; }
    public double TaxAmount { get; set; }
    public double NetAmount { get; set; }

    public double Share { get; set; }
    public double TaxShare { get; set; }
    public double NetShare { get; set; }
}

public enum AmountKind
{
    Price,
    Offer,
    Capacity,
    Ordered,
    Shipped,
    Due,
    Payed,
    Returned,
    Usage,
    Used,
    Required,
    Planned,
    Possibly, 
    Potentially,
    Probablly,
    Forecast,
    Income,
    Outcome,
    Loss,
    Gain,
    Asset,
    Liability
}
