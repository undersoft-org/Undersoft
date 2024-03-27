using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Documentation;

public class DocumentationSSC : DataObject
{
    [Link]
    [VisibleRubric]
    [DisplayRubric("Architecture")]
    public string Architecture { get; set; } = "/presenting/documentation/ssc/architecture";

    [Link]
    [VisibleRubric]
    [DisplayRubric("Reference")]
    public string Reference { get; set; } = "/presenting/documentation/ssc/reference";

    [Link]
    [VisibleRubric]
    [DisplayRubric("API")]
    public string API { get; set; } = "/presenting/documentation/ssc/api";
}

