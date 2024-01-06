using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class BrokerAccount : Account, IViewModel
{
    public BrokerAccount() { Group = AccountGroup.Servicer; }

}
