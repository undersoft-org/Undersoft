using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class RequestActivity : Member, IModel
{
    public RequestActivity() { Group = MemberGroup.Servitizer; }

}
