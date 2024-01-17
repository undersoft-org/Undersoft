using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Contracts.Base;


[DataContract]
public class ResourceBase : ContractBase<ResourceBase, Detail, Setting, ResourceGroup>
{
    public virtual string? Path { get; set; }
}
