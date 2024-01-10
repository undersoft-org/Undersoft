namespace Undersoft.SSC.Entities;

using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Data.Relation;
using Undersoft.SSC.Entities.Enums;

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
