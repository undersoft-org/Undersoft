using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class ComputationActivity : Member, IModel
{
    public ComputationActivity() { Group = MemberGroup.Servitizer; }

}
