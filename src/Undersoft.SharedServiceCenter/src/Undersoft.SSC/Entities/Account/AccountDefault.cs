
using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Relation;

namespace Undersoft.SSC.Entities.Account
{
    public class AccountDefault : DataObject, IEntity
    {
        public virtual RelatedSet<Account>? Accounts { get; set; }

        public virtual RelatedSet<AccountDetail>? Details { get; set; }

        public virtual RelatedSet<AccountSetting>? Settings { get; set; }
    }
}