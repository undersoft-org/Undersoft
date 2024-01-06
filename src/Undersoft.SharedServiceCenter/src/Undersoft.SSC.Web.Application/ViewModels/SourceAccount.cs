using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class SourceAccount : Account, IViewModel
{
    public SourceAccount() { Group = AccountGroup.Servicer; }

}
