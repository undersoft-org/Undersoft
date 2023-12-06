using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.API.Contracts;
using Undersoft.SSC.Web.API.Contracts.Details;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class Servicer : Account, IViewModel
{
    public Servicer() { Group = AccountGroup.Client; }

    public DataObjects<LicenceDetail>? Licences { get; set; }

    public PersonalDetail? Personal { get; set; }

    public CompanyDetail? Company { get; set; }

    public Location? Location { get; set; }

    public DataObjects<EmployeeDetail>? Employees { get; set; }
}
