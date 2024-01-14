using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class ReminderActivity : Member, IModel
{
    public ReminderActivity() { Group = MemberGroup.Servitizer; }

}
