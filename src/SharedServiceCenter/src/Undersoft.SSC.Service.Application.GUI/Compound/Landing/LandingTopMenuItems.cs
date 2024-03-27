using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing;

public class LandingTopMenuItems : DataObject
{
    [Link]
    [VisibleRubric]
    [DisplayRubric("Overview")]
    public string Overview { get; set; } = "/landing/overview";

    [Link]
    [VisibleRubric]
    [DisplayRubric("Ecosystem")]
    public string Ecosystem { get; set; } = "/landing/ecosystem";

    [Link]
    [VisibleRubric]
    [DisplayRubric("Documentation")]
    public string Documentation { get; set; } = "/landing/documentation";

    [Link]
    [VisibleRubric]
    [DisplayRubric("Benchmarks")]
    public string Benchmarks { get; set; } = "/landing/benchmarks";

    [Link]
    [VisibleRubric]
    [DisplayRubric("Downloads")]
    public string Downloads { get; set; } = "/landing/downloads";

    [Link]
    [VisibleRubric]
    [DisplayRubric("Contact")]
    public string Contact { get; set; } = "/landing/contact";
}

