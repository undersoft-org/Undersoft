using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Application.ViewModels;
using Undersoft.SSC.Web.Contracts.Details;

namespace Undersoft.SSC.Web.Appllication.ViewModels;

public class ServicerRegistration : SubAccountRegistration<User, Application.ViewModels.Servicer>
{
    public ServicerRegistration()
    {
        Group = ActivityGroup.Registration;
        Registration = new RegistrationDetail() { Kind = RegistrationKind.Servicer };
    }
}
