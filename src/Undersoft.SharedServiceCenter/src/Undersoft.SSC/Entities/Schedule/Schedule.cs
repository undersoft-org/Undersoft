namespace Undersoft.SSC.Entities.Schedule;

using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Data.Relation;
using Undersoft.SSC.Entities.Account;
using Undersoft.SSC.Entities.Activity;
using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Entities.Resource;

public class Schedule : OpenEntity<Schedule, ScheduleDetail, ScheduleSetting, ScheduleGroup>
{
    public virtual RelatedSet<Schedule>? RelatedFrom { get; set; }

    public virtual RelatedSet<Schedule>? RelatedTo { get; set; }

    public virtual RelatedSet<Account>? Accounts { get; set; }

    public virtual RelatedSet<Activity>? Activities { get; set; }

    public virtual RelatedSet<Resource>? Resources { get; set; }

    public long? DefaultId { get; set; }
    public virtual ScheduleDefault? Default { get; set; }

    public long? LocationId { get; set; }
    public virtual ScheduleLocation? Location { get; set; }
}
