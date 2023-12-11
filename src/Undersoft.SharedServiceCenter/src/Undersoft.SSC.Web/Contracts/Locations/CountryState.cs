
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Undersoft.SSC.Web.Contracts.Locations;

[DataContract]
public class CountryState : DataObject
{
    [DataMember(Order = 12)]
    public string? Name { get; set; }

    [DataMember(Order = 13)]
    public string? StateCode { get; set; }

    [DataMember(Order = 14)]
    public string? TimeZone { get; set; }
}
