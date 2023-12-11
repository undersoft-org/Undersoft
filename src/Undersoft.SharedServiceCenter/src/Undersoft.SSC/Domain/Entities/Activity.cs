namespace Undersoft.SSC.Domain.Entities;

using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SSC.Domain.Entities.Enums;

public class Activity : OpenEntity<Activity, Detail, Setting, ActivityGroup>
{
    public virtual RelatedSet<Activity>? RelatedFrom { get; set; }

    public virtual RelatedSet<Activity>? RelatedTo { get; set; }

    public virtual RelatedSet<Account>? Accounts { get; set; }

    public virtual RelatedSet<Schedule>? Schedules { get; set; }

    public virtual RelatedSet<Resource>? Resources { get; set; }

    public long? DefaultId { get; set; }
    public virtual Default? Default { get; set; }

    public long? LocationId { get; set; }
    public virtual Location? Location { get; set; }    
}
