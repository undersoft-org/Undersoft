using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Web.Application.ViewModels;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Contracts.Details;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class ServiceAccount : Account, IViewModel
{
    public ServiceAccount() { Group = AccountGroup.Servicer; }

    [Detail]
    public IdentityDetail? Identity { get; set; }
}
