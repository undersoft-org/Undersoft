using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK;
using Undersoft.SDK.Instant.Proxies;

namespace Undersoft.SSC.Service.Application.UI.Compound.Operation;

public class PreviewDialog<TDialog, TModel> where TDialog : IDialogContentComponent<TModel> where TModel : class, IOrigin, IInnerProxy
{
    [Inject]
    public IDialogService? DialogService { get; private set; }

    [Inject]
    public IJSRuntime? JS { get; private set; }

    public TModel? Data { get; private set; }

    public async Task Show(TModel data, params string[] allowedList)
    {
        if (allowedList != null && allowedList.Any())
            data.Proxy.Rubrics.ForOnly(r => allowedList.Contains(r.RubricName), r => r.Visible = true).Commit();

        if (DialogService != null)
        {
            var dialog = await DialogService.ShowDialogAsync<TDialog>(data, new DialogParameters()
            {
                Height = "500px",
                Title = $"Preview the {data.Label.ToLower()}",
                PreventDismissOnOverlayClick = true,
                PreventScroll = true,
            });

            var result = await dialog.Result;
            if (!result.Cancelled && result.Data != null)
            {
                Data = (TModel)result.Data;
            }
        }
    }
}
