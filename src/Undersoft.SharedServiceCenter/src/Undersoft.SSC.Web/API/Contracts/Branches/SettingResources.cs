using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;



namespace Undersoft.SSC.Web.API.Contracts.Branches
{
    [DataContract]
    public class SettingResources : Setting, IContract
    {
        public virtual DataObjects<Resource>? Resources { get; set; }
    }
}