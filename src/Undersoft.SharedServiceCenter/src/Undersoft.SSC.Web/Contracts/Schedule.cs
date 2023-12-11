namespace Undersoft.SSC.Web.Contracts;

public class Schedule : ScheduleBase
{
    public virtual DataObjects<ScheduleBase>? RelatedFrom { get; set; }

    public virtual DataObjects<ScheduleBase>? RelatedTo { get; set; }

    public virtual DataObjects<AccountBase>? Accounts { get; set; }

    public virtual DataObjects<ActivityBase>? Activities { get; set; }

    public virtual DataObjects<ResourceBase>? Resources { get; set; }

    public virtual Default? Default { get; set; }

    public virtual Location? Location { get; set; }
}
