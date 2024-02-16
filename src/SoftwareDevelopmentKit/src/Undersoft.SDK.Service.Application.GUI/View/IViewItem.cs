using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Service.Application.GUI.Generic;

namespace Undersoft.SDK.Service.Application.GUI.View
{
    public interface IViewItem : IView
    {
        long Id { get; set; }
        long TypeId { get; set; }
        string? Label { get; set; }
        Icon? Icon { get; set; }
        object? Value { get; set; }
        string? Class { get; set; }
        string? Style { get; set; }
        string? Attributes { get; set; }

        IViewRubric Rubric { get; set; }
    }
}