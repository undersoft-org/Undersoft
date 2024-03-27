using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Documentation;

public class DocumentationSDK : DataObject
{
    [Link]
    [VisibleRubric]
    [DisplayRubric("Reference")]
    public string Reference { get; set; } = "/presenting/documentation/sdk/reference";
}

