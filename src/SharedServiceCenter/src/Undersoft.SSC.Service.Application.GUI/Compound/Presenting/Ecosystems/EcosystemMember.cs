using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Ecosystems;

public class EcosystemMember : DataObject
{
    [Link]
    [VisibleRubric]
    public string? Activities { get; set; } = "/presenting/ecosystem/service/members";
    public Icon ActivitiesIcon = new Icons.Regular.Size20.ShiftsActivity();

    [Link]
    [VisibleRubric]
    public string? Schedules { get; set; } = "/presenting/ecosystem/service/applications";
    public Icon SchedulesIcon = new Icons.Regular.Size20.Timeline();

    [Link]
    [VisibleRubric]
    public string? Resources { get; set; } = "/presenting/ecosystem/service/accounts";
    public Icon ResourcesIcon = new Icons.Regular.Size20.WebAsset();
}

