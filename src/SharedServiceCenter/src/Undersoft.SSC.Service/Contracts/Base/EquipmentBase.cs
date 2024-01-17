using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Contracts.Base;

[DataContract]
public class EquipmentBase : ContractBase<EquipmentBase, Detail, Setting, EquipmentGroup>
{
    [DataMember(Order = 23)]
    public virtual DataObjects<Member>? Members { get; set; }
}
