using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Documentation;

public class DocumentationSSC : DataObject
{
    [Link]
    [VisibleRubric]
    [DisplayRubric("Architecture")]
    public string Architecture { get; set; } = "/presenting/documentation/ssc/architecture";
    public Icon ArchitectureIcon = new Icons.Regular.Size20.DesignIdeas();

    [Link]
    [VisibleRubric]
    [DisplayRubric("References")]
    public string References { get; set; } = "/presenting/documentation/ssc/reference";
    public Icon ReferencesIcon = new Icons.Regular.Size20.AppsListDetail();

    [Link]
    [VisibleRubric]
    [DisplayRubric("API")]
    public string API { get; set; } = "/presenting/documentation/ssc/api";
    public Icon APIIcon = new Icons.Regular.Size20.Connector();
}

