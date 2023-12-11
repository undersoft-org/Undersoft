using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Contracts.Branches;

[DataContract]
public class DetailSchedules : Detail, IContract
{
    public virtual DataObjects<Schedule>? Schedules { get; set; }
}
