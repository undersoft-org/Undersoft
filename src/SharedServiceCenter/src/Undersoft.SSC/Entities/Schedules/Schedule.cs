namespace Undersoft.SSC.Entities.Schedules;

using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;
using Undersoft.SSC.Entities.Members;
using Undersoft.SSC.Entities.Platforms;
using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Entities.Resources;
using Undersoft.SSC.Entities.Activities;

public class Schedule : OpenEntity<Schedule, ScheduleDetail, ScheduleSetting, ScheduleGroup>
{
    public virtual RelatedSet<Schedule>? RelatedFrom { get; set; }

    public virtual RelatedSet<Resource>? RelatedTo { get; set; }

    [Remote] 
    public virtual RemoteSet<Member>? Members { get; set; }
    public virtual RemoteNode<Schedule, Member>? MemberNode { get; set; }
    
    [Remote] 
    public virtual RemoteSet<Resource>? Resources { get; set; }
    public virtual RemoteNode<Schedule, Resource>? ResourceNode { get; set; }

    [Remote] 
    public virtual RemoteSet<Activity>? Activities { get; set; }
    public virtual RemoteNode<Schedule, Activity>? ActivityNode { get; set; }

    public long? DefaultId { get; set; }
    public virtual ScheduleDefault? Default { get; set; }

    public long? LocationId { get; set; } 
    public virtual ScheduleLocation? Location { get; set; }
}
