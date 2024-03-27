using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Benchmarks;
using Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Contacts;
using Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Documentation;
using Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Downloads;
using Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Ecosystems;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing;

public class PresentingNavMenu : DataObject
{
    [Link("/presenting/dashboard")]
    [VisibleRubric]
    [IconRubric("DashboardIcon")]
    public Dashboard Dashboard { get; set; } = new Dashboard();
    public Icon DashboardIcon = new Icons.Regular.Size20.Diagram();

    [VisibleRubric]
    [IconRubric("EcosystemIcon")]
    public Ecosystem Ecosystem { get; set; } = new Ecosystem();
    public Icon EcosystemIcon = new Icons.Regular.Size20.Space3d();

    [VisibleRubric]
    [IconRubric("DocumentationIcon")]
    public Documentation Documentation { get; set; } = new Documentation();
    public Icon DocumentationIcon = new Icons.Regular.Size20.LearningApp();

    [VisibleRubric]
    [IconRubric("BenchmarksIcon")]
    public BenchmarksInstant Benchmarks { get; set; } = new BenchmarksInstant();
    public Icon BenchmarksIcon = new Icons.Regular.Size20.TopSpeed();

    [VisibleRubric]
    [IconRubric("DownloadsIcon")]
    public Downloads Downloads { get; set; } = new Downloads();
    public Icon DownloadsIcon = new Icons.Regular.Size20.AppsList();

    [VisibleRubric]
    [IconRubric("ContactIcon")]
    public Contact Contact { get; set; } = new Contact();
    public Icon ContactIcon = new Icons.Regular.Size20.BookContacts();
}

