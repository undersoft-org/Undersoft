using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class Notification : Member, IModel
{
    public Notification() { Group = MemberGroup.Servitizer; }

}
