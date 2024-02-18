using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu.Software;

public class SoftwareMenu : DataObject
{
    [VisibleRubric]
    public CenterMonitorMenu Solutions { get; set; } = new CenterMonitorMenu();

    [VisibleRubric]
    public DocumentationMenu Manuals { get; set; } = new DocumentationMenu();

    [VisibleRubric]
    public DownloadMenu Resources { get; set; } = new DownloadMenu();

    [VisibleRubric]
    public EcoSystemAdminMenu DevOps { get; set; } = new EcoSystemAdminMenu();
}

