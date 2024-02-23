using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu.Account;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu;

public class AccountTopMenu : DataObject
{
    [VisibleRubric]
    public AccountMenu Account { get; set; } = new AccountMenu();
}

