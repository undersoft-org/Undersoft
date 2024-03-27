using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Ecosystems;

public class EcosystemService : DataObject
{
    [Link]
    [VisibleRubric]
    public string? Members { get; set; } = "/presenting/ecosystem/service/members";
    public Icon MembersIcon = new Icons.Regular.Size20.ServerMultiple();

    [Link]
    [VisibleRubric]
    public string? Applications { get; set; } = "/presenting/ecosystem/service/applications";
    public Icon ApplicationsIcon = new Icons.Regular.Size20.AppFolder();

    [Link]
    [VisibleRubric]
    public string? Accounts { get; set; } = "/presenting/ecosystem/service/accounts";
    public Icon AccountsIcon = new Icons.Regular.Size20.PeopleAdd();
}

