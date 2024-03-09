﻿using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing;

public class LandingTopicMenuItems : DataObject
{
    [Link]
    [VisibleRubric]
    [DisplayRubric("Overview")]
    public string Overview { get; set; } = "/landing/overview";

    [Link]
    [VisibleRubric]
    [DisplayRubric("Benchmarks")]
    public string Benchmarks { get; set; } = "/landing/benchmarks";

    [Link]
    [VisibleRubric]
    [DisplayRubric("Downloads")]
    public string Downloads { get; set; } = "/landing/downloads";

    [Link]
    [VisibleRubric]
    [DisplayRubric("Documentation")]
    public string Documentation { get; set; } = "/landing/documentation";
}

