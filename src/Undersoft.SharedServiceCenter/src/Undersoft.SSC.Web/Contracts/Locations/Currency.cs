using System.Runtime.Serialization;

namespace Undersoft.SSC.Web.Contracts.Locations;

[DataContract]
public partial class Currency : DataObject
{
    [DataMember(Order = 12)]
    public string? Name { get; set; }

    [DataMember(Order = 13)]
    public string? CurrencyCode { get; set; }

    [DataMember(Order = 14)]
    public double Rate { get; set; }
}
