namespace Undersoft.SSC.Entities.Activities;

using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;
using Undersoft.SSC.Entities.Members;
using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Entities.Resources;
using Undersoft.SSC.Entities.Schedules;

public class Activity : OpenEntity<Activity, ActivityDetail, ActivitySetting, ActivityGroup>
{
    public virtual RelatedSet<Activity>? RelatedFrom { get; set; }

    public virtual RelatedSet<Activity>? RelatedTo { get; set; }

    [Remote] 
    public virtual RemoteSet<Member>? Members { get; set; }
    public virtual RemoteNode<Activity, Member>? MemberNode { get; set; }
    
    [Remote] 
    public virtual RemoteSet<Resource>? Resources { get; set; }
    public virtual RemoteNode<Activity, Resource>? ResourceNode { get; set; }

    [Remote] 
    public virtual RemoteSet<Schedule>? Schedules { get; set; } 
    public virtual RemoteNode<Activity, Schedule>? ScheduleNode { get; set; }

    public long? DefaultId { get; set; }
    public virtual ActivityDefault? Default { get; set; }

    public long? LocationId { get; set; }
    public virtual ActivityLocation? Location { get; set; }
}
