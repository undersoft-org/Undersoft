using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;
using Undersoft.SSC.Service.Contracts.Details;

namespace Undersoft.SSC.Service.Application.Models;

public class WorkflowAccount : ModelBase<ServiceAccount, Detail, Setting, AccountGroup>, IModel
{
    public WorkflowAccount() { Group = AccountGroup.Servicer; }

    [Detail]
    public IdentityDetail? Identity { get; set; }
}
