using System.Text.Json.Serialization;

namespace Undersoft.SSC.Web.Contracts;

public class Resource : ResourceBase
{
    public virtual string? Path { get; set; }

    [JsonIgnore]
    public virtual string? ContainerName => System.IO.Path.GetDirectoryName(Path);

    [JsonIgnore]
    public virtual string? FileName => System.IO.Path.GetFileName(Path);

    [JsonIgnore]
    public virtual DataFile? File => new DataFile(Path);

    public virtual DataObjects<ResourceBase>? RelatedFrom { get; set; }

    public virtual DataObjects<ResourceBase>? RelatedTo { get; set; }

    public virtual DataObjects<AccountBase>? Accounts { get; set; }

    public virtual DataObjects<ActivityBase>? Activities { get; set; }

    public virtual DataObjects<ScheduleBase>? Schedules { get; set; }

    public virtual Default? Default { get; set; }

    public virtual Location? Location { get; set; }
}
