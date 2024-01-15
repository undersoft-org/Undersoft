using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class BusMember : Member, IModel
{
    public BusMember() { Group = MemberGroup.Servitizer; }

}
