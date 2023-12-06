using Undersoft.SSC.Web.API.Contracts;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.API.Contracts.Activities;
using Undersoft.SSC.Web.API.Contracts.Branches;

namespace Undersoft.SSC.Web.Application.ViewModels.Edges;

public class ServicerActivities : AccountActivities, IViewModel
{
    public ServicerActivities()
    {
        Group = AccountGroup.Servicer;
    }
}
