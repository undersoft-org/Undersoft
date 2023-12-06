using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;



namespace Undersoft.SSC.Web.API.Contracts.Branches
{
    [DataContract]
    public class SettingSchedules : Setting, IContract
    {
        public virtual DataObjects<Schedule>? Schedules { get; set; }
    }
}