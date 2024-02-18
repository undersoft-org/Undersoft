using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu.General;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu.Access;

public class AccessMenu : DataObject
{
    [VisibleRubric]
    public AdministrationMenu Admin { get; set; } = new AdministrationMenu();

    [VisibleRubric]
    public ManagmentMenu Center { get; set; } = new ManagmentMenu();

    [VisibleRubric]
    public ApplicationMenu App { get; set; } = new ApplicationMenu();

    [VisibleRubric]
    public MonitoringMenu Monitor { get; set; } = new MonitoringMenu();

    [VisibleRubric]
    public ServicesMenu Services { get; set; } = new ServicesMenu();
}

