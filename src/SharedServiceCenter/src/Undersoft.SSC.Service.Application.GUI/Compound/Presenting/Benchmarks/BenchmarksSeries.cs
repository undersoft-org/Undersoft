using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Benchmarks;

public class BenchmarksSeries : DataObject
{
    [Link]
    [VisibleRubric]
    [DisplayRubric("Thread safe")]
    public string ThreadSafe { get; set; } = "/presenting/benchmarks/series/thred_safe";

    [Link]
    [VisibleRubric]
    [DisplayRubric("Non-thread safe")]
    public string NonThreadSafe { get; set; } = "/presenting/benchmarks/series/non_thread_safe";
}

