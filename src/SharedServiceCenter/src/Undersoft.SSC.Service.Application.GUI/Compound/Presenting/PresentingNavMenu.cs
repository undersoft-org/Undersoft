using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Benchmarks;
using Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Contacts;
using Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Dashboard;
using Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Documentation;
using Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Downloads;
using Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Ecosystems;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Presenting;

public class PresentingNavMenu : DataObject
{
    [VisibleRubric]
    [IconRubric("DashboardIcon")]
    [Link("/presenting/dashboard")]
    public PresentingDashboard Dashboard { get; set; } = new PresentingDashboard();
    public Icon DashboardIcon = new Icons.Regular.Size24.ChartMultiple();

    [VisibleRubric]
    [IconRubric("EcosystemIcon")]
    public PresentingEcosystem Ecosystem { get; set; } = new PresentingEcosystem();
    public Icon EcosystemIcon = new Icons.Regular.Size24.System();

    [VisibleRubric]
    [IconRubric("DocumentationIcon")]
    public PresentingDocumentation Documentation { get; set; } = new PresentingDocumentation();
    public Icon DocumentationIcon = new Icons.Regular.Size24.LearningApp();

    [VisibleRubric]
    [IconRubric("BenchmarksIcon")]
    public PresentingBenchmarks Benchmarks { get; set; } = new PresentingBenchmarks();
    public Icon BenchmarksIcon = new Icons.Regular.Size24.TopSpeed();

    [VisibleRubric]
    [IconRubric("DownloadsIcon")]
    public PresentingDownloads Downloads { get; set; } = new PresentingDownloads();
    public Icon DownloadsIcon = new Icons.Regular.Size24.AppsList();

    [VisibleRubric]
    [IconRubric("ContactIcon")]
    public PresentingContact Contact { get; set; } = new PresentingContact();
    public Icon ContactIcon = new Icons.Regular.Size24.BookContacts();
}

