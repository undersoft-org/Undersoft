using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Contracts.Branches
{
    [DataContract]
    public class SettingRelatedTo : Setting, IContract
    {
        public virtual DataObjects<Setting>? RelatedTo { get; set; }
    }
}