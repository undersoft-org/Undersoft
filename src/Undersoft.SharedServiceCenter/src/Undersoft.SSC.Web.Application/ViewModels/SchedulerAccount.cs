﻿using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Web.Application.ViewModels;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Contracts.Details;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class SchedulerAccount : Account, IViewModel
{
    public SchedulerAccount() { Group = AccountGroup.Servicer; }

}