using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Application.GUI.Generic;

namespace Undersoft.SDK.Service.Application.GUI.View
{
    public interface IViewData<TModel> : IViewData, ISeries<IViewData> where TModel : class, IOrigin, IInnerProxy
    {
        new TModel Model { get; set; }
        string? Description { get; set; }
        string? Class { get; set; }
        string? Info { get; set; }
        string? Errors { get; set; }
        string? Success { get; set; }
        bool IsSingle { get; }
        bool HaveNext { get; set; }
        string Height { get; set; }
        Icon? Icon { get; set; }
        bool Canceled { get; set; }
        string? Logo { get; set; }
        string? Href { get; set; }
        string? NextHref { get; set; }
        string? Title { get; set; }
        string Width { get; set; }
        OperationType Operation { get; set; }

        HorizontalAlignment HorizontalAlignment { get; set; }

        ViewDelegates Delegates { get; set; }
        ViewInvokers Invokers { get; set; }

        IView? View { get; set; }

        string? ViewTypeName { get; set; }

        void ClearErrors();

        IViewValidator Validator { get; set; }

        void SetRequired(params string[] requiredList);
        void SetVisible(params string[] visibleList);
        void SetEditable(params string[] editableList);
        void SetDisplayNames(params DisplayPair[] displayPairs);
    }


    public interface IViewData : IView, IIdentifiable
    {
        string ViewId { get; }
        IInnerProxy Model { get; set; }
        IViewRubric ActiveRubric { get; set; }
        IViewRubrics Rubrics { get; set; }
    }
}