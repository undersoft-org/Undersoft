using Undersoft.SSC.Web.Application.ViewModels;
using Undersoft.SSC.Web.Contracts.Details;
using Undersoft.SSC.Web.Enums;

namespace Undersoft.SSC.Web.Appllication.ViewModels;

public class CustomerRegistration : SubAccountRegistration<User, Customer>
{
    public CustomerRegistration()
    {
        Group = ActivityGroup.Registration;
        Registration = new RegistrationDetail() { Kind = RegistrationKind.Client };
    }
}
