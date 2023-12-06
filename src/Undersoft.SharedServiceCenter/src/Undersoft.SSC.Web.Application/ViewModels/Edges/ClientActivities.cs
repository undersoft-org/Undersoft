using Undersoft.SSC.Web.API.Contracts;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.API.Contracts.Activities;
using Undersoft.SSC.Web.API.Contracts.Branches;

namespace Undersoft.SSC.Web.Application.ViewModels.Edges;

public class ClientActivities : AccountActivities, IViewModel
{
    public ClientActivities()
    {
        Group = AccountGroup.Client;
    }
}
