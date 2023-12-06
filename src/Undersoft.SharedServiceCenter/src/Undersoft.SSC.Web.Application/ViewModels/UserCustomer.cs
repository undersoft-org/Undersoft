using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class UserCustomer : User, IViewModel
{
    public UserCustomer() { Group = AccountGroup.User; }

    public virtual DataObjects<Client>? RelatedFrom { get; set; }
}
