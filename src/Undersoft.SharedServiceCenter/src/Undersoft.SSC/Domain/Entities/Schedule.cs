namespace Undersoft.SSC.Domain.Entities;

using Locations;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SSC.Domain.Entities.Enums;

public class Schedule : OpenEntity<Schedule, Detail, Setting, ScheduleGroup>
{
    public virtual RelatedSet<Schedule>? RelatedFrom { get; set; }

    public virtual RelatedSet<Schedule>? RelatedTo { get; set; }    

    public virtual RelatedSet<Account>? Accounts { get; set; }

    public virtual RelatedSet<Activity>? Activities { get; set; }

    public virtual RelatedSet<Resource>? Resources { get; set; }

    public long? DefaultId { get; set; }
    public virtual Default? Default { get; set; }

    public long? LocationId { get; set; }
    public virtual Location? Location { get; set; }
}
