using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;

namespace Undersoft.SSC.Web.API.Contracts
{
    [DataContract]
    public class Default : DataObject, IContract
    {
        public Default() { }

        public virtual Settings<Setting>? Settings { get; set; }
    }
}
