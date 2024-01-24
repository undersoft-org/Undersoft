using System.Runtime.Serialization;
using Undersoft.SSC.Service.Contracts.Base;

namespace Undersoft.SSC.Service.Contracts;

[DataContract]
public class Application : ApplicationBase
{
    [DataMember(Order = 18)]
    public virtual Listing<ApplicationBase>? RelatedFrom { get; set; }

    [DataMember(Order = 19)]
    public virtual Listing<ApplicationBase>? RelatedTo { get; set; }

    [DataMember(Order = 23)]
    public virtual Listing<ServiceBase>? Services { get; set; }

    [DataMember(Order = 25)]
    public virtual Default? Default { get; set; }

    [DataMember(Order = 26)]
    public virtual Location? Location { get; set; }
}


