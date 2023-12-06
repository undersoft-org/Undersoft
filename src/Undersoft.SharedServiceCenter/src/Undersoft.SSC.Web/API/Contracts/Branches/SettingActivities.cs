using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;



namespace Undersoft.SSC.Web.API.Contracts.Branches
{
    [DataContract]
    public class SettingActivities : Setting, IContract
    {
        public virtual DataObjects<Activity>? Activities { get; set; }
    }
}