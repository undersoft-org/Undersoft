using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Contracts.Details;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class MatterAccount : ViewModelBase<ServiceAccount, Detail, Setting, AccountGroup>, IViewModel
{
    public MatterAccount() { Group = AccountGroup.Servicer; }

    [Detail]
    public IdentityDetail? Identity { get; set; }
}
