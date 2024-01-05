using System.ComponentModel.DataAnnotations.Schema;

namespace Undersoft.SSC.Domain.Entities;

using Locations;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SSC.Domain.Entities.Enums;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

public class Resource : OpenEntity<Resource, Detail, Setting, ResourceGroup>
{
    public virtual string? Path { get; set; }

    public virtual RelatedSet<Resource>? RelatedFrom { get; set; }

    public virtual RelatedSet<Resource>? RelatedTo { get; set; }    

    public virtual RelatedSet<Account>? Accounts { get; set; }

    public virtual RelatedSet<Schedule>? Schedules { get; set; }

    public virtual RelatedSet<Activity>? Activities { get; set; }

    public long? DefaultId { get; set; }
    public virtual Default? Default { get; set; }

    public long? LocationId { get; set; }
    public virtual Location? Location { get; set; }
}
