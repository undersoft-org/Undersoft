using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;
using Undersoft.SSC.Service.Contracts.Details;

namespace Undersoft.SSC.Service.Application.Models;

public class ServiceMember : ModelBase<ServiceMember, Detail, Setting, MemberGroup>, IModel
{
    public ServiceMember() { Group = MemberGroup.Servitizer; }

    [Detail]
    public IdentityDetail? Identity { get; set; }
}
