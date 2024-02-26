using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing;

public class LandingAccountMenu : DataObject
{
    [VisibleRubric]
    public LandingAccountMenuItems Account { get; set; } = new LandingAccountMenuItems();
}

