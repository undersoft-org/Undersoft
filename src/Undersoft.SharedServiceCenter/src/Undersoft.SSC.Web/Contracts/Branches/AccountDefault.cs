using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Contracts.Branches;

[DataContract]
public class AccountDefault : AccountBase, IContract
{
    public long? DefaultId { get; set; }
    public virtual Default? Default { get; set; }
}
