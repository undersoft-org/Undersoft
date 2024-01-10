using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Undersoft.SSC.Service.Contracts.Base;

namespace Undersoft.SSC.Service.Contracts;

public class Resource : ResourceBase
{
    public virtual DataObjects<ResourceBase>? RelatedFrom { get; set; }

    public virtual DataObjects<ResourceBase>? RelatedTo { get; set; }

    public virtual DataObjects<AccountBase>? Accounts { get; set; }

    public virtual DataObjects<ActivityBase>? Activities { get; set; }

    public virtual DataObjects<ScheduleBase>? Schedules { get; set; }

    public virtual Default? Default { get; set; }

    public virtual Location? Location { get; set; }
}
