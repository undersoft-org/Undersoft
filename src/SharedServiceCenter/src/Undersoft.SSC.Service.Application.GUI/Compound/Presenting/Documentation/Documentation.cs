using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Documentation;

public class Documentation : DataObject
{
    [ExpandRubric]
    [VisibleRubric]
    [DisplayRubric("SDK")]
    public DocumentationSDK SDK { get; set; } = new DocumentationSDK();
    public Icon SDKIcon = new Icons.Regular.Size20.DeveloperBoardLightning();

    [ExpandRubric]
    [VisibleRubric]
    [DisplayRubric("SSC")]
    public DocumentationSSC SSC { get; set; } = new DocumentationSSC();
    public Icon SSCIcon = new Icons.Regular.Size20.AppGeneric();
}

