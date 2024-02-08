using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Instant.Rubrics;
using Undersoft.SDK.Service.Operation.Command;

namespace Undersoft.SDK.Service.Application.GUI.Generic
{
    public interface IGenericData<TModel> : IGenericData where TModel : class, IOrigin, IInnerProxy
    {
        new TModel Data { get; set; }
    }

    public interface IGenericData
    {
        object? this[int id] { get; set; }
        object? this[string name] { get; set; }
        IInnerProxy Data { get; set; }
        string? Description { get; set; }
        string? Note { get; set; }
        string? Info { get; set; }
        string? Errors { get; set; }
        string? Success { get; set; }
        bool HaveNext { get; set; }
        string Height { get; set; }
        Icon? Icon { get; set; }
        bool IsCanceled { get; set; }
        string? Logo { get; set; }
        string? NextInvoke { get; set; }
        string? NextPath { get; set; }
        IRubrics DisplayRubrics { get; set; }
        string? Title { get; set; }
        string Width { get; set; }
        CommandMode CommandMode { get; set; }

        void SetRequired(params string[] requiredList);
        void SetVisible(params string[] visibleList);
        void SetEditable(params string[] editableList);
        void SetDisplayNames(params DisplayPair[] displayPairs);
    }
}