using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Accounts;

public class AccountMenu : DataObject
{
    [VisibleRubric]
    public AccountMenuItems Account { get; set; } = new AccountMenuItems();
}

