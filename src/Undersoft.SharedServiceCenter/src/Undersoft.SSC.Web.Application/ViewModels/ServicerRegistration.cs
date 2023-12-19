using Undersoft.SSC.Web.Application.ViewModels;
using Undersoft.SSC.Web.Contracts.Details;
using Undersoft.SSC.Web.Enums;

namespace Undersoft.SSC.Web.Appllication.ViewModels;

public class ServicerRegistration : SubAccountRegistration<User, Application.ViewModels.Servicer>
{
    public ServicerRegistration()
    {
        Group = ActivityGroup.Registration;
        Registration = new RegistrationDetail() { Kind = RegistrationKind.Servicer };
    }
}
