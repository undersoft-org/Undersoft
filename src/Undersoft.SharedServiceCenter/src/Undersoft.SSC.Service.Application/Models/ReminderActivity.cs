using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class ReminderActivity : Account, IModel
{
    public ReminderActivity() { Group = AccountGroup.Servicer; }

}
