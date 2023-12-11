namespace Undersoft.SSC.Domain.Entities;

using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SSC.Domain.Entities.Enums;

public class Account : OpenEntity<Account, Detail, Setting, AccountGroup>
{
    public virtual RelatedSet<Account>? RelatedFrom { get; set; }

    public virtual RelatedSet<Account>? RelatedTo { get; set; }

    public virtual RelatedSet<Activity>? Activities { get; set; }

    public virtual RelatedSet<Schedule>? Schedules { get; set; }

    public virtual RelatedSet<Resource>? Resources { get; set; }

    public long? DefaultId { get; set; }
    public virtual Default? Default { get; set; }

    public long? LocationId { get; set; }
    public virtual Location? Location { get; set; }
}
