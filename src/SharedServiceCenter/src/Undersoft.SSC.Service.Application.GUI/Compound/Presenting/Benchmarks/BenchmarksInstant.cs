using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Benchmarks;

public class BenchmarksInstant : DataObject
{
    [Link]
    [VisibleRubric]
    [DisplayRubric("Series")]
    public string Series { get; set; } = "/presenting/benchmarks/instant/series";

    [Link]
    [VisibleRubric]
    [DisplayRubric("Proxies")]
    public string Proxies { get; set; } = "/presenting/benchmarks/instant/proxies";
}

