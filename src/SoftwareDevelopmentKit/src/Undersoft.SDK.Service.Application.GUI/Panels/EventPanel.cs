using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Service.Application.GUI.Generic;

namespace Undersoft.SDK.Service.Application.GUI.Panels;

public class EventPanel<TPanel, TModel> : GenericPanel<TPanel, TModel> where TPanel : IDialogContentComponent<IGenericData<TModel>> where TModel : class, IOrigin, IInnerProxy
{
    public EventPanel(IDialogService dialogService) : base(dialogService)
    {
    }

    public async Task Show()
    {
        if (DialogService != null)
        {
            await this.Show((p) =>
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
