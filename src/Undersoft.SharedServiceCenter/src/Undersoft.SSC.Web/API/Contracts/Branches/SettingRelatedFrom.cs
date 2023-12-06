using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;



namespace Undersoft.SSC.Web.API.Contracts.Branches
{
    [DataContract]
    public class SettingRelatedFrom : Setting, IContract
    {
        public virtual DataObjects<Setting>? RelatedFrom { get; set; }
    }
}