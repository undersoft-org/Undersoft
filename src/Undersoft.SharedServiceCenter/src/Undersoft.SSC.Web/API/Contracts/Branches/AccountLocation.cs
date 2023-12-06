using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;



namespace Undersoft.SSC.Web.API.Contracts.Branches;

[DataContract]
public class AccountLocation : Account, IContract
{
    public long? LocationId { get; set; }
    public virtual Location? Location { get; set; } = new Location();
}
