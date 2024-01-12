namespace Undersoft.SSC.Entities.Activities;

using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Data.Relation;
using Undersoft.SSC.Entities.Enums;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;
using Undersoft.SSC.Entities.Accounts;
using Undersoft.SSC.Entities.Schedules;
using Undersoft.SSC.Entities.Resources;

public class Activity : OpenEntity<Activity, ActivityDetail, ActivitySetting, ActivityGroup>
{
    public virtual RelatedSet<Activity>? RelatedFrom { get; set; }

    public virtual RelatedSet<Activity>? RelatedTo { get; set; }

    [Remote] public virtual RemoteSet<Account>? Accounts { get; set; }

    [Remote] public virtual RemoteSet<Resource>? Resources { get; set; }

    [Remote] public virtual RemoteSet<Schedule>? Schedules { get; set; }

    public virtual RelationNode<Activity, Resource>? ActivitysToResources { get; set; }
    public virtual RelationNode<Account, Activity>? AccountsToActivities { get; set; }
    public virtual RelationNode<Activity, Schedule>? ActivitysToSchedules { get; set; }

    public long? DefaultId { get; set; }
    public virtual ActivityDefault? Default { get; set; }

    public long? LocationId { get; set; }
    public virtual ActivityLocation? Location { get; set; }
}
