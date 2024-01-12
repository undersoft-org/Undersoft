namespace Undersoft.SSC.Entities.Accounts;

using Resources;
using Schedules;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Data.Relation;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;
using Undersoft.SSC.Entities.Activities;
using Undersoft.SSC.Entities.Enums;

public class Account : OpenEntity<Account, AccountDetail, AccountSetting, AccountGroup>
{
    public virtual RelatedSet<Account>? RelatedFrom { get; set; }

    public virtual RelatedSet<Account>? RelatedTo { get; set; }

    [Remote] public virtual RemoteSet<Activity>? Activities { get; set; }

    [Remote] public virtual RemoteSet<Resource>? Resources { get; set; }

    [Remote] public virtual RemoteSet<Schedule>? Schedules { get; set; } 

    public virtual RelationNode<Account, Resource>? AccountsToResources { get; set; }
    public virtual RelationNode<Account, Activity>? AccountsToActivities { get; set; }
    public virtual RelationNode<Account, Schedule>? AccountsToSchedules { get; set; }

    public long? DefaultId { get; set; }
    public virtual AccountDefault? Default { get; set; }
     
    public long? LocationId { get; set; }
    public virtual AccountLocation? Location { get; set; }
}
