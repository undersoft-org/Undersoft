using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Contracts.Details;

namespace Undersoft.SSC.Web.ViewModels;

public class Servicer : AccountBase, IViewModel
{
    public Servicer() { Group = AccountGroup.Servicer; }

    [Detail]
    public IdentityDetail? Identity { get; set; }

    [Detail]
    public PersonalDetail? Personal { get; set; }

    [Detail]
    public DataObjects<LicenceDetail>? Licences { get; set; }
}
