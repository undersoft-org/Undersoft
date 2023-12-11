using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Contracts.Branches;

[DataContract]
public class DetailResources : Detail, IContract
{
    public virtual DataObjects<Resource>? Resources { get; set; }
}
