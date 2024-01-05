﻿using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SSC.Web.Application.ViewModels;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Contracts.Details;
using Undersoft.SSC.Web.Contracts.Settings;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Web.Appllication.ViewModels;

public class ClientAccount : Account, IViewModel
{
    public ClientAccount() { Group = AccountGroup.Client; }

    [Detail]
    public IdentityDetail? Identity { get; set; }

    [Setting]
    public ProfileSetting? Profile { get; set; }
}