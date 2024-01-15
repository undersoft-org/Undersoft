using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class WorkActivity : Member, IModel
{
    public WorkActivity() { Group = MemberGroup.Servitizer; }

}
