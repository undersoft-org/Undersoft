using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text.Json.Serialization;

namespace Undersoft.SSC.Web.API.Contracts.Locations;

[DataContract]
public class Endpoint : DataObject
{
    public string? Host { get; set; }

    public string? IP { get; set; }

    public int? Port { get; set; }

    public string? URI { get; set; }
}
