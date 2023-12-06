using System.Text.Json.Serialization;
using Undersoft.SDK.Instant.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Web.API.Contracts;

public class Resource : DataObject, IContract
{
    public virtual string? Path { get; set; }

    [JsonIgnore]
    public virtual string? ContainerName => System.IO.Path.GetDirectoryName(Path);

    [JsonIgnore]
    public virtual string? FileName => System.IO.Path.GetFileName(Path);

    [JsonIgnore]
    public virtual DataFile? File => new DataFile(Path);

    public virtual Identifiers<Resource>? Identifiers { get; set; }

    public virtual Details<Detail>? Details { get; set; }

    public virtual Settings<Setting>? Settings { get; set; }

    [IdentityRubric]
    public virtual ResourceGroup? Group { get; set; }
}
