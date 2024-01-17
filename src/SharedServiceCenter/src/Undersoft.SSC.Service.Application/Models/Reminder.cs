using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class Reminder : Member, IModel
{
    public Reminder() { Group = MemberGroup.Servitizer; }

}
