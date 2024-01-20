using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class Service : ModelBase<Service, Detail, Setting, MemberGroup>, IModel
{
    public Service() { Group = MemberGroup.Servitizer; }

    [Detail]
    public Contracts.Account? Identity { get; set; }
}
