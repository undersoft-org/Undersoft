using Undersoft.SSC.Web.Application.ViewModels;
using Undersoft.SSC.Web.Contracts.Details;
using Undersoft.SSC.Web.Enums;
using Undersoft.SSC.Web.ViewModels;

namespace Undersoft.SSC.Web.Appllication.ViewModels;

public class OrganizationRegistration : AccountRegistration<Organization>
{
    public OrganizationRegistration()
    {
        Group = ActivityGroup.Registration;
        Registration = new RegistrationDetail() { Kind = RegistrationKind.Organization };
    }
}
