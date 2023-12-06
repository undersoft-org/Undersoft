using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class ServicerUser : Servicer, IViewModel
{
    public ServicerUser() { Group = AccountGroup.User; }

    public virtual DataObjects<User>? RelatedTo { get; set; }
}
