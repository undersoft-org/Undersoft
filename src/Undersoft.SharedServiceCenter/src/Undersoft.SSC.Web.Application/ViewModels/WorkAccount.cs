using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class WorkAccount : Account, IViewModel
{
    public WorkAccount() { Group = AccountGroup.Servicer; }

}
