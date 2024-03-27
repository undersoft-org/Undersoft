using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Ecosystems;

public class EcosystemCenter : DataObject
{
    [Link]
    [VisibleRubric]
    public string? Applications { get; set; } = "/presenting/ecosystem/center/applications";
    public Icon ApplicationsIcon = new Icons.Regular.Size20.AppGeneric();


    [Link]
    [VisibleRubric]
    public string? Services { get; set; } = "/presenting/ecosystem/center/services";
    public Icon ServicesIcon = new Icons.Regular.Size20.ServiceBell();

    [Link]
    [VisibleRubric]
    public string? Accounts { get; set; } = "/presenting/ecosystem/center/accounts";
    public Icon AccountsIcon = new Icons.Regular.Size20.PeopleSettings();
}

