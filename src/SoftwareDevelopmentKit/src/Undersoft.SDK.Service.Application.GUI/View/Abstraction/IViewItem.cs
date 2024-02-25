using Microsoft.FluentUI.AspNetCore.Components;

namespace Undersoft.SDK.Service.Application.GUI.View.Abstraction
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
        object? Reference { get; set; }

        IViewRubric Rubric { get; set; }

        IViewData Data { get; set; }
    }
}