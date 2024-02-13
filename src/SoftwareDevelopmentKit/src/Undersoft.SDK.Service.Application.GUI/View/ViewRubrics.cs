﻿using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Series;

namespace Undersoft.SDK.Service.Application.GUI.View;

public class ViewRubrics : Registry<ViewRubric>, IViewRubrics
{
    public IInstantSeries? Series { get; set; }

    public IViewRubrics? KeyRubrics { get; set; }
}
