using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing;

public class LandingTopicMenu : DataObject
{
    [VisibleRubric]
    public LandingTopicMenuItems Categories { get; set; } = new LandingTopicMenuItems();
}

