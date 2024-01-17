namespace Undersoft.SSC.Domain.Entities;

using System.ComponentModel.DataAnnotations.Schema;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;
using Undersoft.SSC.Domain.Entities.Enums;

public class Activity : OpenEntity<Activity, Detail, Setting, ActivityGroup>
{
    public virtual RelatedSet<Activity>? RelatedFrom { get; set; }

    public virtual RelatedSet<Activity>? RelatedTo { get; set; }

    public virtual RelatedSet<Member>? Members { get; set; }

    public virtual RelatedSet<Resource>? Resources { get; set; }

    public virtual RelatedSet<Schedule>? Schedules { get; set; }

    public long? DefaultId { get; set; }
    public virtual Default? Default { get; set; }

    [ForeignKey(nameof(Location))]
    public long? LocationId { get; set; }
    public virtual Location? Location { get; set; }
}
