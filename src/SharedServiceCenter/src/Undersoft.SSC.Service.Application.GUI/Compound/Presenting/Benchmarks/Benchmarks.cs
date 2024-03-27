using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Benchmarks;

public class Benchmarks : DataObject
{
    [ExpandRubric]
    [VisibleRubric]
    [DisplayRubric("Instant (JIT)")]
    public BenchmarksInstant Instant { get; set; } = new BenchmarksInstant();
    public Icon InstantIcon = new Icons.Regular.Size20.TableLightning();

    [ExpandRubric]
    [VisibleRubric]
    [DisplayRubric("Series (Data structures)")]
    public BenchmarksSeries Series { get; set; } = new BenchmarksSeries();
    public Icon SeriesIcon = new Icons.Regular.Size20.DataUsageToolbox();
}

