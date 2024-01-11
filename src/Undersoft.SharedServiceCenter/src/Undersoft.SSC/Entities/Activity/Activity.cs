namespace Undersoft.SSC.Entities.Activity;

using Schedule;
using Resource;
using Account;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Data.Relation;
using Undersoft.SSC.Entities.Enums;

public class Activity : OpenEntity<Activity, ActivityDetail, ActivitySetting, ActivityGroup>
{
    public virtual RelatedSet<Activity>? RelatedFrom { get; set; }

    public virtual RelatedSet<Activity>? RelatedTo { get; set; }

    public virtual RelatedSet<Account>? Accounts { get; set; }

    public virtual RelatedSet<Schedule>? Schedules { get; set; }

    public virtual RelatedSet<Resource>? Resources { get; set; }

    public long? DefaultId { get; set; }
    public virtual ActivityDefault? Default { get; set; }

    public long? LocationId { get; set; }
    public virtual ActivityLocation? Location { get; set; }
}
