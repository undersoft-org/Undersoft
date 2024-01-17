namespace Undersoft.SSC.Domain.Entities;

using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;
using Undersoft.SSC.Domain.Entities.Enums;

public class Resource : OpenEntity<Resource, Detail, Setting, ResourceGroup>
{
    public virtual RelatedSet<Resource>? RelatedFrom { get; set; }

    public virtual RelatedSet<Resource>? RelatedTo { get; set; }

    public virtual RelatedSet<Activity>? Activities { get; set; }

    public virtual RelatedSet<Member>? Members { get; set; }

    public virtual RelatedSet<Schedule>? Schedules { get; set; }

    public long? DefaultId { get; set; }
    public virtual Default? Default { get; set; }

    public long? LocationId { get; set; }
    public virtual Location? Location { get; set; }
}
