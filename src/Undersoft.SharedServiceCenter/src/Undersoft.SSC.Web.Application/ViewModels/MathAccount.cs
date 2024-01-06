using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class MathAccount : Account, IViewModel
{
    public MathAccount() { Group = AccountGroup.Servicer; }

}
