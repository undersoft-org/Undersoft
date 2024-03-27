using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Documentation;

public class DocumentationSDK : DataObject
{
    [Link]
    [VisibleRubric]
    [DisplayRubric("References")]
    public string References { get; set; } = "/presenting/documentation/sdk/reference";
    public Icon ReferencesIcon = new Icons.Regular.Size20.AppsListDetail();
}

