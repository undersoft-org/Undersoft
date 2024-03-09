using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Access;
using Undersoft.SDK.Service.Application.GUI.View;
using Undersoft.SDK.Service.Application.GUI.View.Abstraction;
using Undersoft.SDK.Updating;
using Undersoft.SSC.Service.Application.GUI.Compound.Access.Dialog;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Access
{
    public partial class RegisterBase : ComponentBase
    {
        [Inject]
        private IAccountService<Account> _access { get; set; } = default!;

        [Inject]
        private NavigationManager _navigation { get; set; } = default!;

        [Inject]
        private IServicer _servicer { get; set; } = default!;

        [Inject]
        private IAuthorization _authorization { get; set; } = default!;

        [Inject]
        public IDialogService DialogService { get; set; } = default!;

        private IViewDialog<Account> _dialog = default!;

        protected override void OnInitialized()
        {
            _dialog = _servicer.Initialize<AccessDialog<RegisterDialog<Account, AccountValidator>, Account>>(DialogService);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
                await Registering("Registration");
        }

        private async Task Registering(string title, string description = "")
        {
            var account = new Account() { Personal = new AccountPersonal(), Address = new AccountAddress(), Professional = new AccountProfessional(), Organization = new AccountOrganization() };

            _authorization.Credentials.PatchTo(account.Personal);
            _authorization.Credentials.PatchTo(account.Professional);

            var data = new ViewData<Account>(account, OperationType.Any, title);
            data.SetVisible(nameof(Account.Personal), nameof(Account.Address), nameof(Account.Professional), nameof(Account.Organization));
            data.Description = description;
            data.Height = "700px";
            data.Width = "400px";

            while (true)
            {
                await _dialog.Show(data);

                var content = _dialog.Content;

                if (content != null)
                {
                    var result = await _access.Register(content.Model);

                    if (result.Notes.Status != SigningStatus.InvalidEmail && result.Notes.Status == SigningStatus.RegistrationNotConfirmed)
                    {
                        _navigation.NavigateTo($"access/complete_registration/{result.Credentials.Email}");
                        return;
                    }

                    data.ClearData();
                    result.Notes.PatchTo(data.Notes);
                }
                else
                {
                    _navigation.NavigateTo("", true);
                    return;
                }
            }
        }
    }
}