using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class SchedulerAccount : Account, IViewModel
{
    public SchedulerAccount() { Group = AccountGroup.Servicer; }

}
