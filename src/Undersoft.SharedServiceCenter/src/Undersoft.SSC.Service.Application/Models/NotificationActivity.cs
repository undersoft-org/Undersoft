﻿using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class NotificationActivity : Account, IModel
{
    public NotificationActivity() { Group = AccountGroup.Servicer; }

}
