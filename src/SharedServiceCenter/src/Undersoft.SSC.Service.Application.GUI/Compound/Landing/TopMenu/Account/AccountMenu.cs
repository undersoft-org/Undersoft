using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu.Account;

public class AccountMenu : DataObject
{
    [VisibleRubric]
    public ProfileMenu Profile { get; set; } = new ProfileMenu();

    [VisibleRubric]
    [DisplayRubric("Sign up")]
    public SignUpMenu SignUp { get; set; } = new SignUpMenu();

    [VisibleRubric]
    [DisplayRubric("Sign in")]
    public SignInMenu SignIn { get; set; } = new SignInMenu();

    [VisibleRubric]
    [DisplayRubric("Sign out")]
    public SignOutMenu SignOut { get; set; } = new SignOutMenu();
}

