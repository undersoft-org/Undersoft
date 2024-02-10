using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK;
using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Service.Application.GUI.Generic;
using Undersoft.SDK.Service.Application.GUI.View;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Setup;

public class SetupPanel<TPanel, TModel> : ViewPanel<TPanel, TModel> where TPanel : IDialogContentComponent<IViewData<TModel>> where TModel : class, IOrigin, IInnerProxy
{
    public SetupPanel(IDialogService dialogService) : base(dialogService)
    {
    }

    public override async Task Show(IViewData<TModel> data)
    {
        if (Service != null)
        {
            var dialog = await Service.ShowPanelAsync<TPanel>(data, new DialogParameters<TModel>()
            {
                Height = data.Height,
                Width = data.Width,
                Title = data.Title,
                ShowTitle = true,
                Alignment = HorizontalAlignment.Right,
                PrimaryAction = "OK",
                SecondaryAction = null,
                ShowDismiss = true
            });

            var result = await dialog.Result;
            if (!result.Cancelled && result.Data != null)
            {
                Content = (IViewData<TModel>)result.Data;
            }
        }
    }
}
