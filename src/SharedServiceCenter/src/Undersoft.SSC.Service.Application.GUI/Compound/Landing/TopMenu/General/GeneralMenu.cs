using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu.General;

public class GeneralMenu : DataObject
{
    [VisibleRubric]
    public TechOverviewMenu Overview { get; set; } = new TechOverviewMenu();

    [VisibleRubric]
    public AuthorMenu Author { get; set; } = new AuthorMenu();

    [VisibleRubric]
    public HistoryMenu History { get; set; } = new HistoryMenu();

    [VisibleRubric]
    public ContactMenu Contact { get; set; } = new ContactMenu();
}

