using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Ecosystems;

public class EcosystemAplication : DataObject
{
    [Link]
    [VisibleRubric]
    public string? Members { get; set; } = "/presenting/ecosystem/application/members";
    public Icon MembersIcon = new Icons.Regular.Size20.Compose();

    [Link]
    [VisibleRubric]
    public string? Services { get; set; } = "/presenting/ecosystem/application/services";
    public Icon ServicesIcon = new Icons.Regular.Size20.ServerLink();
}

