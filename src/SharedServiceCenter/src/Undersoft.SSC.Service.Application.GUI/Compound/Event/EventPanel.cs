using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK;
using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Service.Application.GUI.Generic;
using Undersoft.SDK.Service.Application.GUI.View;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Event;

public class EventPanel<TPanel, TModel> : ViewPanel<TPanel, TModel> where TPanel : IDialogContentComponent<IViewData<TModel>> where TModel : class, IOrigin, IInnerProxy
{
    public EventPanel(IDialogService dialogService) : base(dialogService)
    {
    }

    public async Task Show()
    {
        if (Service != null)
        {
            await Show((p) =>
            {
                p.Alignment = HorizontalAlignment.Right;
                p.Title = $"Notifications";
                p.PrimaryAction = null;
                p.SecondaryAction = null;
                p.ShowDismiss = true;
            });
        }
    }

    private static void HandlePanel(DialogResult result)
    {
        if (result.Cancelled)
        {
            return;
        }

        if (result.Data is not null)
        {
            return;
        }
    }
}
