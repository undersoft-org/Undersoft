using System.Runtime.Serialization;
using Undersoft.SSC.Service.Contracts.Base;

namespace Undersoft.SSC.Service.Contracts;

[DataContract]
public class Resource : ResourceBase
{
    [DataMember(Order = 25)]
    public virtual ObjectSet<ResourceBase>? RelatedFrom { get; set; }

    [DataMember(Order = 26)]
    public virtual ObjectSet<ResourceBase>? RelatedTo { get; set; }

    [DataMember(Order = 27)]
    public virtual ObjectSet<MemberBase>? Members { get; set; }

    [DataMember(Order = 28)]
    public virtual ObjectSet<ActivityBase>? Activities { get; set; }

    [DataMember(Order = 29)]
    public virtual ObjectSet<ScheduleBase>? Schedules { get; set; }

    [DataMember(Order = 17)]
    public virtual Default? Default { get; set; }

    [DataMember(Order = 19)]
    public virtual Location? Location { get; set; }
}
