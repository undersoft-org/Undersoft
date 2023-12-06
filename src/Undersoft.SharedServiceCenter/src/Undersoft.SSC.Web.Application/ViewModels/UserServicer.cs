using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class UserServicer : User, IViewModel
{
    public UserServicer() { Group = AccountGroup.User; }

    public virtual DataObjects<Servicer>? RelatedFrom { get; set; }
}
