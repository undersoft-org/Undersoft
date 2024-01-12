namespace Undersoft.SSC.Entities.Resources;

using Schedules;
using Activities;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Data.Relation;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;
using Undersoft.SSC.Entities.Accounts;
using Undersoft.SSC.Entities.Enums;

public class Resource : OpenEntity<Resource, ResourceDetail, ResourceSetting, ResourceGroup>
{
    public virtual RelatedSet<Resource>? RelatedFrom { get; set; }

    public virtual RelatedSet<Resource>? RelatedTo { get; set; }

    [Remote] public virtual RemoteSet<Account>? Accounts { get; set; }

    [Remote] public virtual RemoteSet<Resource>? Resources { get; set; }

    [Remote] public virtual RemoteSet<Schedule>? Schedules { get; set; }

    public virtual RelationNode<Activity, Resource>? ActivitysToResources { get; set; }
    public virtual RelationNode<Account, Resource>? AccountsToActivities { get; set; }
    public virtual RelationNode<Resource, Schedule>? ResourcesToSchedules { get; set; }

    public long? DefaultId { get; set; }
    public virtual ResourceDefault? Default { get; set; } 

    public long? LocationId { get; set; }
    public virtual ResourceLocation? Location { get; set; }
}
 