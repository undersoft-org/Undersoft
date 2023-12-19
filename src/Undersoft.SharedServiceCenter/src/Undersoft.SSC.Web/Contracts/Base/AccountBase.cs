using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SSC.Web.Enums;

namespace Undersoft.SSC.Web.Contracts;

[DataContract]
public class AccountBase : ContractBase<AccountBase, Detail, Setting, AccountGroup>
{
}
