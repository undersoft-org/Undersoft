using Undersoft.SDK.Service.Application.GUI.Rubrics;

namespace Undersoft.SDK.Service.Application.GUI.Generic
{
    public interface IGenericField
    {
        long Id { get; set; }
        IViewRubric Rubric { get; set; }
        long TypeId { get; set; }
        object? Value { get; set; }

        void NotifyStateHasChanged();
    }
}