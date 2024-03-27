using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Ecosystems;

public class PresentingEcosystem : DataObject
{
    [ExpandRubric]
    [VisibleRubric]
    public EcosystemCenter Center { get; set; } = new EcosystemCenter();
    public Icon CenterIcon = new Icons.Regular.Size20.BuildingSkyscraper();

    [ExpandRubric]
    [VisibleRubric]
    public EcosystemService Service { get; set; } = new EcosystemService();
    public Icon ServiceIcon = new Icons.Regular.Size20.ServerMultiple();

    [ExpandRubric]
    [VisibleRubric]
    public EcosystemAplication Application { get; set; } = new EcosystemAplication();
    public Icon ApplicationIcon = new Icons.Regular.Size20.Apps();

    [ExpandRubric]
    [VisibleRubric]
    public EcosystemMember Member { get; set; } = new EcosystemMember();
    public Icon MemberIcon = new Icons.Regular.Size20.Compose();
}

