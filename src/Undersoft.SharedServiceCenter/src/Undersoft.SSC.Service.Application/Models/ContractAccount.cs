using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;
using Undersoft.SSC.Service.Contracts.Details;

namespace Undersoft.SSC.Service.Application.Models;

public class ContractAccount : Account, IModel
{
    public ContractAccount() { Group = AccountGroup.Organization; }

    [Detail]
    public IdentityDetail? Identity { get; set; }

    [Detail]
    public PersonalDetail? Personal { get; set; }

    [Detail]
    public MathDetail? Company { get; set; }

    [Detail]
    public DataObjects<RequestDetail>? Employees { get; set; }

    [Detail]
    public DataObjects<ResponseDetail>? Licences { get; set; }
}
