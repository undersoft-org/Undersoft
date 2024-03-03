﻿using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Application.GUI.View.Abstraction;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SSC.Service.Application.GUI.Compound.Access;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing;

public class LandingAccountMenuItems : DataObject
{
    [VisibleRubric]
    [Invoke(typeof(LandingAccountPanel), "OpenAccountPanel")]
    public IViewPanel<Account> Account { get; set; } = default!;

    [Link]
    [VisibleRubric]
    [DisplayRubric("sign up")]
    public string SignUp { get; set; } = "/access/sign_up";

    [Link]
    [VisibleRubric]
    [DisplayRubric("sign in")]
    public string SignIn { get; set; } = "/access/sign_in";

    [Link]
    [VisibleRubric]
    [DisplayRubric("sign out")]
    public string SignOut { get; set; } = "/access/sign_out";
}

