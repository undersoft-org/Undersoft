namespace Undersoft.SSC.Entities.Platforms;

using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;
using Undersoft.SSC.Entities.Members;
using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Entities.Resources;
using Undersoft.SSC.Entities.Schedules;

public class Platform : OpenEntity<Platform, PlatformDetail, PlatformSetting, PlatformGroup>
{
    public virtual RelatedSet<Platform>? RelatedFrom { get; set; }

    public virtual RelatedSet<Platform>? RelatedTo { get; set; }

    [Remote] 
    public virtual RemoteSet<Member>? Members { get; set; }
    public virtual RemoteNode<Platform, Member>? MemberNode { get; set; }
    
    [Remote] 
    public virtual RemoteSet<Resource>? Resources { get; set; }
    public virtual RemoteNode<Platform, Resource>? ResourceNode { get; set; }

    [Remote] 
    public virtual RemoteSet<Schedule>? Schedules { get; set; } 
    public virtual RemoteNode<Platform, Schedule>? ScheduleNode { get; set; }

    public long? DefaultId { get; set; }
    public virtual PlatformDefault? Default { get; set; }

    public long? LocationId { get; set; }
    public virtual PlatformLocation? Location { get; set; }
}
