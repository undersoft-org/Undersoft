using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;



namespace Undersoft.SSC.Web.API.Contracts.Branches;

[DataContract]
public class DetailRelatedFrom : Detail, IContract
{
    public virtual DataObjects<Detail>? RelatedFrom { get; set; }
}
