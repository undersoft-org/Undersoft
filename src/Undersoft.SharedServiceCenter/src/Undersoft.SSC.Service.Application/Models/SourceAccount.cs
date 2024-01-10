using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class SourceAccount : Account, IModel
{
    public SourceAccount() { Group = AccountGroup.Servicer; }

}
