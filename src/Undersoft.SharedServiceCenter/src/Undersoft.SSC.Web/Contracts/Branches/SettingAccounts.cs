using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Contracts.Branches
{
    [DataContract]
    public class SettingAccounts : Setting, IContract
    {
        public virtual DataObjects<AccountBase>? Accounts { get; set; }
    }
}