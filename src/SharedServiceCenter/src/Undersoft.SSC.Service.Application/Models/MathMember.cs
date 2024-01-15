using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class MathMember : Member, IModel
{
    public MathMember() { Group = MemberGroup.Servitizer; }

}
