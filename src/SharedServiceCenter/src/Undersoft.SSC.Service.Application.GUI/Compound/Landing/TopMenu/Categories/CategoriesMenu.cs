using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu.Categories;

public class CategoriesMenu : DataObject
{
    [VisibleRubric]
    public OverviewMenu Overview { get; set; } = new OverviewMenu();

    [VisibleRubric]
    public TechnologyMenu Technology { get; set; } = new TechnologyMenu();

    [VisibleRubric]
    public SoftwareMenu Software { get; set; } = new SoftwareMenu();

    [VisibleRubric]
    public AdvantageMenu Advantage { get; set; } = new AdvantageMenu();

    [VisibleRubric]
    public AccessMenu Access { get; set; } = new AccessMenu();
}

