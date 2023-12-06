
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Undersoft.SSC.Web.API.Contracts.Locations;

[DataContract]
public class CountryState : DataObject
{
    public string? Name { get; set; }

    public string? StateCode { get; set; }

    public string? TimeZone { get; set; }

}
