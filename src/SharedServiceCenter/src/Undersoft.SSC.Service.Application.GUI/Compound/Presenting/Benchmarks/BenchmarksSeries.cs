using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Benchmarks;

public class BenchmarksSeries : DataObject
{
    [Link]
    [VisibleRubric]
    [DisplayRubric("Thread safe")]
    public string ThreadSafe { get; set; } = "/presenting/benchmarks/series/thred_safe";
    public Icon ThreadSafeIcon = new Icons.Regular.Size20.ShieldTask();

    [Link]
    [VisibleRubric]
    [DisplayRubric("Non-thread safe")]
    public string NonThreadSafe { get; set; } = "/presenting/benchmarks/series/non_thread_safe";
    public Icon NonThreadSafeIcon = new Icons.Regular.Size20.WarningShield();
}

