using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class OperationActivity : Account, IModel
{
    public OperationActivity() { Group = AccountGroup.Servicer; }

}
