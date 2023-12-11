using Undersoft.SDK.Service.Application.Account.Identity;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Contracts.Details;
using Undersoft.SSC.Web.Contracts.Settings;
using Undersoft.SSC.Web.ViewModels;

namespace Undersoft.SSC.Web.Appllication.ViewModels;

public class UserServicerRegistration : Activity, IViewModel
{
    public UserServicerRegistration()
    {
        Group = ActivityGroup.Registration;
    }

    public DataObjects<User> Accounts { get; set; } = new DataObjects<User>();

    [Detail]
    public RegistrationDetail Registration { get; set; } = new RegistrationDetail() { Kind = RegistrationKind.Servicer };

    public User? User
    {
        get
        {
            if (Accounts.Count > 0)
                return Accounts?.Where(a => a.Group != AccountGroup.User).FirstOrDefault();
            var user = new User();
            Accounts.Add(user);
            return user;
        }
        set
        {
            if (Accounts.Count > 0)
                Accounts?.Where(a => a.Group != AccountGroup.User).FirstOrDefault().PatchFrom(value);
            else if (value != null)
                Accounts.Add(value);
        }
    }

    public Web.ViewModels.Servicer? Servicer
    {
        get
        {
            var servicer = User?.Servicer; if (servicer == null) { servicer = new Web.ViewModels.Servicer(); User?.RelatedTo?.Add(servicer); }
            return servicer;
        }
    }
}
