using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class WorkActivity : Account, IModel
{
    public WorkActivity() { Group = AccountGroup.Servicer; }

}
