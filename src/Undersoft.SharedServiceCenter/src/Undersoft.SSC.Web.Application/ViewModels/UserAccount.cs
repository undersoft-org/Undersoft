using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SSC.Web.Application.ViewModels;
using Undersoft.SSC.Web.Appllication.ViewModels;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Contracts.Details;
using Undersoft.SSC.Web.Contracts.Settings;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class UserAccount : ViewModelBase<UserAccount, Detail, Setting, AccountGroup>, IViewModel
{
    public UserAccount() { Group = AccountGroup.User; }

    [Detail]
    public IdentityDetail? Identity { get; set; }

    [Detail]
    public PersonalDetail? Personal { get; set; }

    [Setting]
    public ProfileSetting? Profile { get; set; }

    [Detail]
    public DataObjects<LicenceDetail>? Licences { get; set; }
}
