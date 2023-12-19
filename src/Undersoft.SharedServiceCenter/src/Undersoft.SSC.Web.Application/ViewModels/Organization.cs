﻿using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Web.Application.ViewModels;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Contracts.Details;
using Undersoft.SSC.Web.Enums;

namespace Undersoft.SSC.Web.ViewModels;

public class Organization : AccountModel, IViewModel
{
    public Organization() { Group = AccountGroup.Organization; }

    [Detail]
    public IdentityDetail? Identity { get; set; }

    [Detail]
    public PersonalDetail? Personal { get; set; }

    [Detail]
    public CompanyDetail? Company { get; set; }

    [Detail]
    public DataObjects<EmployeeDetail>? Employees { get; set; }
}
