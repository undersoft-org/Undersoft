using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing;

public class LandingTopicMenuItems : DataObject
{
    [Link]
    [VisibleRubric]
    [DisplayRubric("overview")]
    public string Overview { get; set; } = "/landing/overview";

    [Link]
    [VisibleRubric]
    [DisplayRubric("advantages")]
    public string Advantages { get; set; } = "/landing/advantages";

    [Link]
    [VisibleRubric]
    [DisplayRubric("development")]
    public string Development { get; set; } = "/landing/development";

    [Link]
    [VisibleRubric]
    [DisplayRubric("shared services")]
    public string SharedServices { get; set; } = "/landing/shared_services";
}

