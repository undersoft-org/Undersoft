﻿using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class NotificationAccount : Account, IViewModel
{
    public NotificationAccount() { Group = AccountGroup.Servicer; }

}
