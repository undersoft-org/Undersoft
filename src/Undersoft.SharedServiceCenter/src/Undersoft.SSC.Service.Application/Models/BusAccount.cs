using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class BusAccount : Account, IModel
{
    public BusAccount() { Group = AccountGroup.Servicer; }

}
