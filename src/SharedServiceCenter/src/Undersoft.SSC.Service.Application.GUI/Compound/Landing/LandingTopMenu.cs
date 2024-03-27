using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing;

public class LandingTopMenu : DataObject
{
    [VisibleRubric]
    [IconRubric("MenuIcon")]
    public LandingTopMenuItems Menu { get; set; } = new LandingTopMenuItems();

    public Icon MenuIcon = new Icons.Regular.Size20.Navigation();
}

