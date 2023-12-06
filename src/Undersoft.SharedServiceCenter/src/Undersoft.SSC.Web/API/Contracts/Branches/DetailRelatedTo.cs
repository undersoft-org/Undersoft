using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;



namespace Undersoft.SSC.Web.API.Contracts.Branches;

[DataContract]
public class DetailRelatedTo : Detail, IContract
{
    public virtual DataObjects<Detail>? RelatedTo { get; set; }
}
