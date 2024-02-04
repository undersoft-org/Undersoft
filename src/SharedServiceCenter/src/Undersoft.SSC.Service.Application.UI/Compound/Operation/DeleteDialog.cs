using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK;
using Undersoft.SDK.Instant.Proxies;

namespace Undersoft.SSC.Service.Application.UI.Compound.Operation;

public class DeleteDialog<TDialog, TModel> where TDialog : IDialogContentComponent<TModel> where TModel : class, IOrigin, IInnerProxy
{
    [Inject]
    public IDialogService? DialogService { get; private set; }

    [Inject]
    public IJSRuntime? JS { get; private set; }

    public TModel? Data { get; private set; }

    public async Task Show(TModel data)
    {
        if (DialogService != null)
        {
            var dialog = await DialogService.ShowDialogAsync<TDialog>(new DialogParameters()
            {
                Height = "150px",
                Title = $"Delete the {data.Label.ToLower()}. Please confirm!> ",
                PreventDismissOnOverlayClick = true,
                PreventScroll = true,
            });

            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                Data = (TModel)data;
            }
        }
    }
}
