﻿using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Service.Application.GUI.Rubrics;
using Undersoft.SDK.Service.Operation.Command;

namespace Undersoft.SDK.Service.Application.GUI.Generic
{
    public interface IGenericData<TModel> : IGenericData where TModel : class, IOrigin, IInnerProxy
    {
        new TModel Model { get; set; }
    }

    public interface IGenericData
    {
        IInnerProxy Model { get; set; }
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
        IViewRubric SelectedRubric { get; set; }
        IViewRubrics ViewRubrics { get; set; }
        string? Title { get; set; }
        string Width { get; set; }
        CommandMode CommandMode { get; set; }

        IInvoker FormValidator { get; set; }
        IInvoker FieldValidator { get; set; }

        void SetRequired(params string[] requiredList);
        void SetVisible(params string[] visibleList);
        void SetEditable(params string[] editableList);
        void SetDisplayNames(params DisplayPair[] displayPairs);
    }
}