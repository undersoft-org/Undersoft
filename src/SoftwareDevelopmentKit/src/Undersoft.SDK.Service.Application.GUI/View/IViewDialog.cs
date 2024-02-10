using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Service.Application.GUI.Generic;

namespace Undersoft.SDK.Service.Application.GUI.View
{
    public interface IViewDialog<TModel> where TModel : class, IOrigin, IInnerProxy
    {
        IViewData<TModel>? Content { get; }
        IDialogReference? Reference { get; }
        IDialogService Service { get; }

        Task Show(IViewData<TModel> data);

        Task Show(IViewData<TModel> data, Action<DialogParameters> setup);

        Task Show(Action<DialogParameters<TModel>> setup);
    }
}