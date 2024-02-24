using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu.Account;

public class AccountMenu : DataObject
{
    [Link]
    [VisibleRubric]
    public string Profile { get; set; } = "/access/profile";

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

