using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Service.Application.GUI.View;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Access;

public class AccountPanel
{
    public AccountPanel() { }

    public async Task OpenAccountPanel(IViewPanel<Account> _panel)
    {
        await _panel.Show(new ViewData<Account>(), (p) =>
           {
               p.Alignment = HorizontalAlignment.Right;
               p.Title = $"Account";
               p.PrimaryAction = "Ok";
               p.SecondaryAction = null;
               p.ShowDismiss = true;
           });

        HandlePanel(_panel.Content);
    }

    public void HandlePanel(IViewData<Account>? result)
    {

    }
}