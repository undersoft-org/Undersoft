using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class SourceMember : Member, IModel
{
    public SourceMember() { Group = MemberGroup.Servitizer; }

}
