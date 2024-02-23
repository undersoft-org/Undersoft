using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu.Account;

public class AccountMenu : DataObject
{
    [VisibleRubric]
    public ProfileMenu Profile { get; set; } = new ProfileMenu();

    [VisibleRubric]
    public SignInMenu SignIn { get; set; } = new SignInMenu();

    [VisibleRubric]
    public SignOutMenu SignOut { get; set; } = new SignOutMenu();
}

