using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class TargetAccount : Account, IViewModel
{
    public TargetAccount() { Group = AccountGroup.Servicer; }

}
