using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Contracts.Branches
{
    [DataContract]
    public class SettingActivities : Setting, IContract
    {
        public virtual DataObjects<Activity>? Activities { get; set; }
    }
}