using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class ViewModelAccount : Account, IViewModel
{
    public ViewModelAccount() { Group = AccountGroup.Servicer; }

}
