using System.Runtime.Serialization;
using Undersoft.SSC.Service.Contracts.Base;

namespace Undersoft.SSC.Service.Contracts;

[DataContract]
public class Infrastructure : InfrastructureBase
{
    [DataMember(Order = 18)]
    public virtual DataObjects<InfrastructureBase>? RelatedFrom { get; set; }

    [DataMember(Order = 19)]
    public virtual DataObjects<InfrastructureBase>? RelatedTo { get; set; }

    [DataMember(Order = 23)]
    public virtual DataObjects<ServiceBase>? Services { get; set; }

    [DataMember(Order = 24)]
    public virtual Default? Default { get; set; }

    [DataMember(Order = 25)]
    public virtual Location? Location { get; set; }
}


