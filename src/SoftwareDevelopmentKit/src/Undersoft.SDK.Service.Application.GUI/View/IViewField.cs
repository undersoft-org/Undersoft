namespace Undersoft.SDK.Service.Application.GUI.View
{
    public interface IViewField
    {
        long Id { get; set; }
        long TypeId { get; set; }
        object? Value { get; set; }
        string? Class { get; set; }
        string? Style { get; set; }
        string? Attributes { get; set; }

        IViewRubric Rubric { get; set; }

        void RenderView();
    }
}