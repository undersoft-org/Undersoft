using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;



namespace Undersoft.SSC.Web.API.Contracts.Branches
{
    [DataContract]
    public class SettingRelatedTo : Setting, IContract
    {
        public virtual DataObjects<Setting>? RelatedTo { get; set; }
    }
}