using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Contracts.Branches
{
    [DataContract]
    public class DefaultAccounts : Default, IContract
    {
        public virtual DataObjects<AccountDefault>? Accounts { get; set; }
    }
}
