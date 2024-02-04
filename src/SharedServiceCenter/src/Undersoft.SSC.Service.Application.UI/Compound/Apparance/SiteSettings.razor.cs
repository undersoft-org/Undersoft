using Microsoft.FluentUI.AspNetCore.Components;

namespace Undersoft.SSC.Service.Application.UI.Compound.Apparance;

public partial class SiteSettings
{
    private IDialogReference? _dialog;

    public async Task OpenSiteSettingsAsync()
    {
        _dialog = await DialogService.ShowPanelAsync<SiteSettingsPanel>(new DialogParameters()
        {
            ShowTitle = true,
            Title = "Site settings",
            Alignment = HorizontalAlignment.Right,
            PrimaryAction = "OK",
            SecondaryAction = null,
            ShowDismiss = true
        });

        DialogResult result = await _dialog.Result;
    }
}
