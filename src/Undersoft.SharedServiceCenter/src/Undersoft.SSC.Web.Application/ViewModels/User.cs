using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Appllication.ViewModels;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Contracts.Details;
using Undersoft.SSC.Web.Contracts.Settings;

namespace Undersoft.SSC.Web.ViewModels;

public class User : AccountBase, IViewModel
{
    public User() { Group = AccountGroup.User; }

    [Detail]
    public IdentityDetail? Identity { get; set; }

    [Detail]
    public PersonalDetail? Personal { get; set; }

    [Setting]
    public ProfileSetting? Profile { get; set; }

    public DataObjects<AccountBase>? RelatedFrom { get; set; }

    public DataObjects<AccountBase>? RelatedTo { get; set; }

    public Organization? Organization => RelatedFrom?.Where(a => a.Group != AccountGroup.Organization).FirstOrDefault() as Organization;

    public Client? Client => RelatedTo?.Where(a => a.Group != AccountGroup.Client).FirstOrDefault() as Client;

    public Servicer? Servicer => RelatedTo?.Where(a => a.Group != AccountGroup.Servicer).FirstOrDefault() as Servicer;
}
