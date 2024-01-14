using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Undersoft.SSC.Entities.Resources;

namespace Undersoft.SSC.Entities.Schedules.Locations;

public class Endpoint : DataObject
{
    public string? Host { get; set; }

    public string? IP { get; set; }

    public int? Port { get; set; }

    public string? URI { get; set; }

    public string? OS { get; set; }

    public long? LocationId { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual ScheduleLocation? Location { get; set; }
}
