using Undersoft.SDK.Service.Application.Account.Identity;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Contracts.Details;
using Undersoft.SSC.Web.Contracts.Settings;
using Undersoft.SSC.Web.ViewModels;

namespace Undersoft.SSC.Web.Appllication.ViewModels;

public class Client : AccountBase, IViewModel
{
    public Client() { Group = AccountGroup.Client; }

    [Detail]
    public IdentityDetail? Identity { get; set; }

    [Setting]
    public ProfileSetting? Profile { get; set; }
}
