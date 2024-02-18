using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu.Access;
using Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu.Advantage;
using Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu.General;
using Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu.Software;
using Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu.Technology;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu;

public class LandingTopMenu : DataObject
{
    [VisibleRubric]
    public GeneralMenu info { get; set; } = new GeneralMenu();

    [VisibleRubric]
    public TechnologyMenu tech { get; set; } = new TechnologyMenu();

    [VisibleRubric]
    public SoftwareMenu soft { get; set; } = new SoftwareMenu();

    [VisibleRubric]
    public AdvantageMenu pros { get; set; } = new AdvantageMenu();

    [VisibleRubric]
    public AccessMenu enter { get; set; } = new AccessMenu();
}

