using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class RepositoryAccount : Account, IModel
{
    public RepositoryAccount() { Group = AccountGroup.Servicer; }

}
