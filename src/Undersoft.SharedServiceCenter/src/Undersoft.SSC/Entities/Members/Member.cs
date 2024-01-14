namespace Undersoft.SSC.Entities.Members;

using Resources;
using Schedules;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;
using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Entities.Activities;

public class Member : OpenEntity<Member, MemberDetail, MemberSetting, MemberGroup>
{
    public virtual RelatedSet<Member>? RelatedFrom { get; set; }

    public virtual RelatedSet<Member>? RelatedTo { get; set; }

    [Remote]
    public virtual RemoteSet<Activity>? Activities { get; set; }
    public virtual RemoteNode<Member, Activity>? ActivityNode { get; set; }

    [Remote] 
    public virtual RemoteSet<Resource>? Resources { get; set; }
    public virtual RemoteNode<Member, Resource>? ResourceNode { get; set; } 
     
    [Remote]
    public virtual RemoteSet<Schedule>? Schedules { get; set; }
    public virtual RemoteNode<Member, Schedule>? ScheduleNode { get; set; }

    public long? DefaultId { get; set; }
    public virtual MemberDefault? Default { get; set; }

    public long? LocationId { get; set; }
    public virtual MemberLocation? Location { get; set; }
}
