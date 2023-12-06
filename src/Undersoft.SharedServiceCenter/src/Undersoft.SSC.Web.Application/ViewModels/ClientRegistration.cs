using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.API.Contracts;
using Undersoft.SSC.Web.API.Contracts.Activities;
using Undersoft.SSC.Web.API.Contracts.Branches;
using Undersoft.SSC.Web.Application.ViewModels.Edges;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class ClientRegistration : ClientActivities, IViewModel
{
    public AccountRegistration? Registration
    {
        get =>
            base.Activities
                ?.Where(a => a.Group == ActivityGroup.AccountRegistration)
                .Cast<AccountRegistration>()
                .FirstOrDefault();
        set => base.Activities.PatchFrom(new[] { value as Activity });
    }
}
