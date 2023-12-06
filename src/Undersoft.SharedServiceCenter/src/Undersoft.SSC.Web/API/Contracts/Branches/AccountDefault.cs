using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;



namespace Undersoft.SSC.Web.API.Contracts.Branches;

[DataContract]
public class AccountDefault : Account, IContract
{
    public long? DefaultId { get; set; }
    public virtual Default? Default { get; set; }
}
