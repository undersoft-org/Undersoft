namespace Undersoft.SSC.Domain.Entities;

using System.ComponentModel.DataAnnotations.Schema;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SSC.Domain.Entities.Enums;

public class Member : OpenEntity<Member, Detail, Setting, MemberGroup>
{
    public virtual RelatedSet<Member>? RelatedFrom { get; set; }

    public virtual RelatedSet<Member>? RelatedTo { get; set; }

    public virtual RelatedSet<Application>? Applications { get; set; }

    public virtual RelatedSet<Service>? Services { get; set; }

    public virtual RelatedSet<Activity>? Activities { get; set; }

    public virtual RelatedSet<Resource>? Resources { get; set; }

    public virtual RelatedSet<Schedule>? Schedules { get; set; }

    public long? DefaultId { get; set; }
    public virtual Default? Default { get; set; }

    [ForeignKey(nameof(Location))]
    public long? LocationId { get; set; }
    public virtual Location? Location { get; set; }
}
