﻿using Undersoft.SDK.Service.Application.GUI.Generic;

namespace Undersoft.SDK.Service.Application.GUI.View
{
    public interface IViewField : IView
    {
        long Id { get; set; }
        long TypeId { get; set; }
        object? Value { get; set; }
        string? Class { get; set; }
        string? Style { get; set; }
        string? Attributes { get; set; }

        IViewRubric Rubric { get; set; }
    }
}