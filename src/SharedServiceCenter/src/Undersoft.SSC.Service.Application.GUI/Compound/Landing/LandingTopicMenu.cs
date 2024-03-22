using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing;

public class LandingTopicMenu : DataObject
{
    [VisibleRubric]
    [IconRubric("MenuIcon")]
    public LandingTopicMenuItems Menu { get; set; } = new LandingTopicMenuItems();

    public Icon MenuIcon = new Icons.Regular.Size20.Navigation();
}

