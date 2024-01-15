using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class RepositoryMember : Member, IModel
{
    public RepositoryMember() { Group = MemberGroup.Servitizer; }

}
