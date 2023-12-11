using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Contracts.Branches;

[DataContract]
public class AccountLocation : AccountBase, IContract
{
    public long? LocationId { get; set; }
    public virtual Location? Location { get; set; } = new Location();
}
