using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;



namespace Undersoft.SSC.Web.API.Contracts.Branches
{
    [DataContract]
    public class DefaultSchedules : Default, IContract
    {
        public virtual DataObjects<Schedule>? Schedules { get; set; }
    }
}
