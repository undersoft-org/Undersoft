namespace Undersoft.SSC.Entities.Resources;

using Schedules;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;
using Undersoft.SSC.Entities.Activities;
using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Entities.Members;

public class Resource : OpenEntity<Resource, ResourceDetail, ResourceSetting, ResourceGroup>
{
    public virtual RelatedSet<Resource>? RelatedFrom { get; set; }

    public virtual RelatedSet<Resource>? RelatedTo { get; set; }

    [Remote] 
    public virtual RemoteSet<Member>? Members { get; set; }
    public virtual RemoteNode<Resource, Member>? MemberNode { get; set; }

    [Remote]
    public virtual RemoteSet<Activity>? Activities { get; set; }
    public virtual RemoteNode<Resource, Activity>? ActivityNode { get; set; }

    [Remote] 
    public virtual RemoteSet<Schedule>? Schedules { get; set; }
    public virtual RemoteNode<Resource, Schedule>? ScheduleNode { get; set; }

    public long? DefaultId { get; set; }
    public virtual ResourceDefault? Default { get; set; }

    public long? LocationId { get; set; }
    public virtual ResourceLocation? Location { get; set; }
}
 