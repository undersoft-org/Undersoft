using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class Request : Member, IModel
{
    public Request() { Group = MemberGroup.Servitizer; }

}
