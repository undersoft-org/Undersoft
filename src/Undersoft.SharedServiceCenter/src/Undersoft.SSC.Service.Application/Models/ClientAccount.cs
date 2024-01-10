using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;
using Undersoft.SSC.Service.Contracts.Details;
using Undersoft.SSC.Service.Contracts.Settings;

namespace Undersoft.SSC.Service.Application.Models;

public class ClientAccount : ModelBase<ClientAccount, Detail, Setting, AccountGroup>, IModel
{
    public ClientAccount() { Group = AccountGroup.Client; }

    [Detail]
    public IdentityDetail? Identity { get; set; }

    [Setting]
    public ProfileSetting? Profile { get; set; }
}
