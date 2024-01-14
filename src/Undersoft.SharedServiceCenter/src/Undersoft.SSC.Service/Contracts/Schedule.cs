using Undersoft.SSC.Service.Contracts.Base;

namespace Undersoft.SSC.Service.Contracts;

public class Schedule : ScheduleBase
{
    public virtual DataObjects<ScheduleBase>? RelatedFrom { get; set; }

    public virtual DataObjects<ScheduleBase>? RelatedTo { get; set; }

    public virtual DataObjects<MemberBase>? Members { get; set; }

    public virtual DataObjects<ActivityBase>? Activities { get; set; }

    public virtual DataObjects<ResourceBase>? Resources { get; set; }

    public virtual Default? Default { get; set; }

    public virtual Location? Location { get; set; }
}
