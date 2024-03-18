using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK;
using Undersoft.SDK.Service.Application.GUI.View;
using Undersoft.SDK.Service.Application.GUI.View.Abstraction;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Access;

public class LandingAccountPanel
{
    public LandingAccountPanel() { }

    public async Task OpenAccountPanel(IViewPanel<Account> _panel)
    {
        var account = new Account() { Personal = new AccountPersonal(), Address = new AccountAddress(), Professional = new AccountProfessional(), Organization = new AccountOrganization() };

        var data = new ViewData<Account>(account, OperationType.Any);
        data.SetVisible(nameof(Account.Personal), nameof(Account.Address), nameof(Account.Professional), nameof(Account.Organization));
        data.Width = "380px";
        await _panel.Show(data, (p) =>
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