namespace Undersoft.SDK.Service.Application.GUI.View
{
    public interface IViewField
    {
        long Id { get; set; }
        IViewRubric Rubric { get; set; }
        long TypeId { get; set; }
        object? Value { get; set; }

        void NotifyStateHasChanged();
    }
}