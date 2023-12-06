using Undersoft.SDK.Service.Application.Account.Identity;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.API.Contracts;
using Undersoft.SSC.Web.API.Contracts.Details;
using Undersoft.SSC.Web.API.Contracts.Settings;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class User : Account, IViewModel
{
    public User() { Group = AccountGroup.User; }

    public Location? Location { get; set; }

    public PersonalDetail? Personal { get; set; }

    public AccountIdentity? Identity { get; set; }

    public ProfileSettings? Profile { get; set; }
}
