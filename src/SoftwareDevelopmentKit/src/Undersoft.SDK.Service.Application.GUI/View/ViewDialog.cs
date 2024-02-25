using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Service.Application.GUI.View.Abstraction;

namespace Undersoft.SDK.Service.Application.GUI.View;

public class ViewDialog<TDialog, TModel> : IViewDialog<TModel> where TDialog : IDialogContentComponent<IViewData<TModel>> where TModel : class, IOrigin, IInnerProxy
{
    public ViewDialog(IDialogService dialogService)
    {
        Service = dialogService;
    }

    public IDialogService Service { get; private set; }

    public IViewData<TModel>? Content { get; set; }

    public IDialogReference? Reference { get; set; }

    public virtual async Task Show(IViewData<TModel> data)
    {
        if (Service != null)
        {
            Reference = await Service.ShowDialogAsync<TDialog>(data, new DialogParameters()
            {
                Height = data.Height,
                Width = data.Width,
                Title = data.Title,
                Id = data.Model.TypeId.ToString()
            });

            var result = await Reference.Result;
            if (!result.Cancelled && result.Data != null)
            {
                Content = (IViewData<TModel>)result.Data;
            }
        }
    }

    public virtual async Task Show(IViewData<TModel> data, Action<DialogParameters> setup)
    {
        if (Service != null)
        {
            var parameters = new DialogParameters();
            parameters.Height = data.Height;
            parameters.Width = data.Width;
            parameters.Title = data.Title;
            parameters.Id = data.Model.TypeId.ToString();
            setup(parameters);
            Reference = await Service.ShowDialogAsync<TDialog>(data, parameters);

            var result = await Reference.Result;
            if (!result.Cancelled && result.Data != null)
            {
                Content = (IViewData<TModel>)result.Data;
            }
        }
    }

    public virtual async Task Show(Action<DialogParameters<TModel>> setup)
    {
        if (Service != null)
        {
            var parameters = new DialogParameters<TModel>();
            setup(parameters);
            Reference = await Service.ShowDialogAsync<TDialog>(parameters);

            var result = await Reference.Result;
            if (!result.Cancelled && result.Data != null)
            {
                Content = (IViewData<TModel>)result.Data;
            }
        }
    }

    public virtual async Task Update(string id, IViewData<TModel> data, Action<DialogParameters>? setup = null)
    {
        if (Service != null)
        {
            var parameters = new DialogParameters<IViewData<TModel>>();
            parameters.Height = data.Height;
            parameters.Width = data.Width;
            parameters.Title = data.Title;
            parameters.Id = data.Model.TypeId.ToString();
            parameters.Content = data;
            if (setup != null)
                setup(parameters);
            Reference = await Service.UpdateDialogAsync<IViewData<TModel>>(id, parameters);
        }
    }

    public void RenderView()
    {
        if (Content?.View != null)
            Content.View.RenderView();
    }
}
