using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class SchedulerMember : Member, IModel
{
    public SchedulerMember() { Group = MemberGroup.Servitizer; }

}
