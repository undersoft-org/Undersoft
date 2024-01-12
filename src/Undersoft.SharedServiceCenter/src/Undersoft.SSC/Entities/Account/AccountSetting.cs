using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Entities.Accounts
{
    public class AccountSetting : ObjectSetting<AccountSetting, SettingKind>, IEntity, ISerializableJsonDocument, ISetting
    {
        public virtual RelatedSet<AccountSetting>? RelatedFrom { get; set; }

        public virtual RelatedSet<AccountSetting>? RelatedTo { get; set; }

        public virtual RelatedSet<Account>? Accounts { get; set; }

        public virtual long DefaultId { get; set; }
        public virtual AccountDefault? Default { get; set; }
    }
}