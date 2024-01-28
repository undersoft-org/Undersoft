using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Service.Contracts.Base;

namespace Undersoft.SSC.Service.Contracts;

[DataContract]
public class Service : ServiceBase, IContract
{
    [DataMember(Order = 20)]
    public virtual ObjectSet<ServiceBase>? RelatedFrom { get; set; }

    [DataMember(Order = 21)]
    public virtual ObjectSet<ServiceBase>? RelatedTo { get; set; }

    [DataMember(Order = 23)]
    public virtual ObjectSet<ApplicationBase>? Applications { get; set; }

    [DataMember(Order = 17)]
    public virtual Default? Default { get; set; }

    [DataMember(Order = 19)]
    public virtual Location? Location { get; set; }
}


