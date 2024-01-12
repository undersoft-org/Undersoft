using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;
using Undersoft.SSC.Service.Contracts.Details;
using Undersoft.SSC.Service.Contracts.Settings;

namespace Undersoft.SSC.Service.Application.Models;

public class UserAccount : ModelBase<UserAccount, Detail, Setting, AccountGroup>, IModel
{
    public UserAccount() { Group = AccountGroup.User; }

    [Detail]
    public IdentityDetail? Identity { get; set; }

    [Detail]
    public PersonalDetail? Personal { get; set; }

    [Setting]
    public ProfileSetting? Profile { get; set; }

    [Detail]
    public DataObjects<ResponseDetail>? Licences { get; set; }
}
