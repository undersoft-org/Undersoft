using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class QueryAccount : Account, IViewModel
{
    public QueryAccount() { Group = AccountGroup.Servicer; }

}
