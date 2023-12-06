
using Undersoft.SSC.Web.API.Contracts.Details;

namespace Undersoft.SSC.Web.API.Contracts.Activities;

public class AccountRegistration : Activity
{
    public AccountRegistration() { }

    public CompanyDetail? Company { get; set; }

    public PersonalDetail? Personal { get; set; }

    public DataObjects<EmployeeDetail>? Employees { get; set; }

    public DataObjects<LicenceDetail>? Licences { get; set; }
}
