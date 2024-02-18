using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu.General;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu.Technology;

public class TechnologyMenu : DataObject
{
    [VisibleRubric]
    public TechOverviewMenu Overview { get; set; } = new TechOverviewMenu();

    [VisibleRubric]
    public EcoSystemMenu Design { get; set; } = new EcoSystemMenu();

    [VisibleRubric]
    public TechStackMenu Stack { get; set; } = new TechStackMenu();

    [VisibleRubric]
    public AppEngineMenu Engine { get; set; } = new AppEngineMenu();

    [VisibleRubric]
    public SdkLibraryMenu SDK { get; set; } = new SdkLibraryMenu();
}

