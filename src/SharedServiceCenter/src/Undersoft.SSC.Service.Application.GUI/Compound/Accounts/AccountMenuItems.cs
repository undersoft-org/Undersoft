﻿using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Application.GUI.View.Abstraction;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SSC.Service.Application.GUI.Compound.Access;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Accounts;

public class AccountMenuItems : DataObject
{
    [VisibleRubric]
    [DisplayRubric("Account")]
    [Invoke(typeof(AccountPanel), "OpenAccountPanel")]
    public IViewPanel<Account> Account { get; set; } = default!;

    [Link]
    [VisibleRubric]
    [DisplayRubric("Sign up")]
    public string SignUp { get; set; } = "/access/sign_up";

    [Link]
    [VisibleRubric]
    [DisplayRubric("Sign in")]
    public string SignIn { get; set; } = "/access/sign_in";

    [Link]
    [VisibleRubric]
    [DisplayRubric("Sign out")]
    public string SignOut { get; set; } = "/access/sign_out";
}

