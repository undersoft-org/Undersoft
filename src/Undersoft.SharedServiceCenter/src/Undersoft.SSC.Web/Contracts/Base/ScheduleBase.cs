using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Web.Contracts;

[DataContract]
public class ScheduleBase : ContractBase<ScheduleBase, Detail, Setting, ScheduleGroup>
{
}
