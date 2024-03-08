using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing;

public class LandingTopicMenuItems : DataObject
{
    [Link]
    [VisibleRubric]
    [DisplayRubric("Overview")]
    public string Overview { get; set; } = "/landing/overview";

    [Link]
    [VisibleRubric]
    [DisplayRubric("Advantages")]
    public string Advantages { get; set; } = "/landing/advantages";

    [Link]
    [VisibleRubric]
    [DisplayRubric("Ecosystems")]
    public string Ecosystems { get; set; } = "/landing/ecosystems";

    [Link]
    [VisibleRubric]
    [DisplayRubric("Shared services")]
    public string SharedServices { get; set; } = "/landing/shared_services";
}

