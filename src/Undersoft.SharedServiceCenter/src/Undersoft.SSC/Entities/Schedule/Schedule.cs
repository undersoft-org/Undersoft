namespace Undersoft.SSC.Entities.Schedules;

using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Data.Relation;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;
using Undersoft.SSC.Entities.Accounts;
using Undersoft.SSC.Entities.Activities;
using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Entities.Resources;

public class Schedule : OpenEntity<Schedule, ScheduleDetail, ScheduleSetting, ScheduleGroup>
{
    public virtual RelatedSet<Schedule>? RelatedFrom { get; set; }

    public virtual RelatedSet<Resource>? RelatedTo { get; set; }

    [Remote] public virtual RemoteSet<Account>? Accounts { get; set; }

    [Remote] public virtual RemoteSet<Resource>? Resources { get; set; }

    [Remote] public virtual RemoteSet<Activity>? Activities { get; set; }

    public virtual RelationNode<Activity, Schedule>? ActivitysToResources { get; set; }
    public virtual RelationNode<Account, Schedule>? AccountsToActivities { get; set; }
    public virtual RelationNode<Resource, Schedule>? ResourcesToSchedules { get; set; }

    public long? DefaultId { get; set; }
    public virtual ScheduleDefault? Default { get; set; }

    public long? LocationId { get; set; } 
    public virtual ScheduleLocation? Location { get; set; }
}
