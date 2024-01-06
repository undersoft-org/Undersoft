using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class OrchestratorAccount : Account, IViewModel
{
    public OrchestratorAccount() { Group = AccountGroup.Servicer; }

}
