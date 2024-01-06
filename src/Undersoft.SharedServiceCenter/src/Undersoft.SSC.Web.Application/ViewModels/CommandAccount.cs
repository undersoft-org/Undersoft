using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class CommandAccount : Account, IViewModel
{
    public CommandAccount() { Group = AccountGroup.Servicer; }

}
