using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class MathAccount : Account, IModel
{
    public MathAccount() { Group = AccountGroup.Servicer; }

}
