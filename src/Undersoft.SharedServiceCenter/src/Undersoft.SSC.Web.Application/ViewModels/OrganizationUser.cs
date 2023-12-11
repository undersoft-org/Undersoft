using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Contracts.Details;

namespace Undersoft.SSC.Web.ViewModels;

public class OrganizationUser : Organization, IViewModel
{
    public OrganizationUser() { Group = AccountGroup.Organization; }

    public DataObjects<User>? RelatedTo { get; set; }

    public IEnumerable<User>? Users => RelatedTo?.Where(a => a.Group != AccountGroup.User);

}
