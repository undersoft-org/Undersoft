using System.Runtime.Serialization;

namespace Undersoft.SSC.Web.Contracts;

[DataContract]
public class Account : AccountBase
{
    [DataMember(Order = 18)]
    public virtual DataObjects<AccountBase>? RelatedFrom { get; set; }

    [DataMember(Order = 19)]
    public virtual DataObjects<AccountBase>? RelatedTo { get; set; }

    [DataMember(Order = 20)]
    public virtual DataObjects<ActivityBase>? Activities { get; set; }

    [DataMember(Order = 21)]
    public virtual DataObjects<ResourceBase>? Resources { get; set; }

    [DataMember(Order = 22)]
    public virtual DataObjects<ScheduleBase>? Schedules { get; set; }

    [DataMember(Order = 23)]
    public virtual Default? Default { get; set; }

    [DataMember(Order = 24)]
    public virtual Location? Location { get; set; }
}


