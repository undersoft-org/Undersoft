﻿using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Service.Contracts;
using Undersoft.SSC.Service.Contracts.Details;

namespace Undersoft.SSC.Service.Application.Models;

public class Contract : Member, IModel
{
    public Contract() { Group = MemberGroup.Organization; }

    [Detail]
    public Contracts.Details.Account? Identity { get; set; }

    [Detail]
    public Personal? Personal { get; set; }

    [Detail]
    public Expression? Company { get; set; }

    [Detail]
    public DataObjects<Contracts.Details.Request>? Employees { get; set; }

    [Detail]
    public DataObjects<Contracts.Details.Response>? Licences { get; set; }
}
