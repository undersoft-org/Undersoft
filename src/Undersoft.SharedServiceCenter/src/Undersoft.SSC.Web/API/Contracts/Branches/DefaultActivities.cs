using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;



namespace Undersoft.SSC.Web.API.Contracts.Branches
{
    [DataContract]
    public class DefaultActivities : Default, IContract
    {
        public virtual DataObjects<ActivityDefault>? Activities { get; set; }
    }
}
