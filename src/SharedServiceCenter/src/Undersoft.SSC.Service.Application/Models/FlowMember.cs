using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;
using Undersoft.SSC.Service.Contracts.Details;

namespace Undersoft.SSC.Service.Application.Models;

public class FlowMember : ModelBase<ServiceMember, Detail, Setting, MemberGroup>, IModel
{
    public FlowMember() { Group = MemberGroup.Servitizer; }

    [Detail]
    public AccountDetail? Identity { get; set; }
}
