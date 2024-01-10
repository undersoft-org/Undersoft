using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class SchedulerAccount : Account, IModel
{
    public SchedulerAccount() { Group = AccountGroup.Servicer; }

}
