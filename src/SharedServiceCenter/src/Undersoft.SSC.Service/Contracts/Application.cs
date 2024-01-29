using System.Runtime.Serialization;
using Undersoft.SSC.Service.Contracts.Base;

namespace Undersoft.SSC.Service.Contracts;

[DataContract]
public class Application : ApplicationBase
{
    [DataMember(Order = 20)]
    public virtual ObjectSet<ApplicationBase>? RelatedFrom { get; set; }

    [DataMember(Order = 21)]
    public virtual ObjectSet<ApplicationBase>? RelatedTo { get; set; }

    [DataMember(Order = 23)]
    public virtual ObjectSet<ServiceBase>? Services { get; set; }

    [DataMember(Order = 17)]
    public virtual Default? Default { get; set; }

    [DataMember(Order = 19)]
    public virtual Location? Location { get; set; }
}


