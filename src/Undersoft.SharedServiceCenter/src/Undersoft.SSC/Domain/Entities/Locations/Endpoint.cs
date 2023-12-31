using Undersoft.SDK.Service.Data.Object;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text.Json.Serialization;
using Undersoft.SSC.Domain.Entities;


namespace Undersoft.SSC.Domain.Entities.Locations;

public class Endpoint : DataObject
{
    public string? Host { get; set; }

    public string? IP { get; set; }

    public int? Port { get; set; }

    public string? URI { get; set; }

    public long? LocationId { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual Location? Location { get; set; }
}
