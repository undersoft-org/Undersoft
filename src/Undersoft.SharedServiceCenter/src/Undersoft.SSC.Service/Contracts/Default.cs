using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SDK.Service.Data.Object.Setting;

namespace Undersoft.SSC.Service.Contracts
{
    [DataContract]
    public class Default : DataObject, IContract
    {
        [DataMember(Order = 12)]
        public virtual Settings<Setting>? Settings { get; set; }
    }
}
