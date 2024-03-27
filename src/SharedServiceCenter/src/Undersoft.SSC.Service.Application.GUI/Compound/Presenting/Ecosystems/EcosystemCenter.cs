using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Ecosystems;

public class EcosystemCenter : DataObject
{
    [Link]
    [VisibleRubric]
    [DisplayRubric("Shared services")]
    public string? SharedServices { get; set; } = "/presenting/ecosystem/center/shared_services";
    public Icon SharedServicesIcon = new Icons.Regular.Size20.ServiceBell();

    [Link]
    [VisibleRubric]
    public string? Accounts { get; set; } = "/presenting/ecosystem/center/accounts";
    public Icon AccountsIcon = new Icons.Regular.Size20.PeopleSettings();
}

