using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Access;
using Undersoft.SDK.Service.Application.GUI.View;
using Undersoft.SDK.Service.Application.GUI.View.Abstraction;
using Undersoft.SDK.Service.Application.GUI.View.Generic.Form.Dialog;
using Undersoft.SSC.Service.Application.GUI.Compound.Access.Dialog;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Access
{
    public partial class ChangePasswordBase : ComponentBase
    {
        [Inject]
        private IAccountAccess _access { get; set; } = default!;

        [Inject]
        private NavigationManager _navigation { get; set; } = default!;

        [Inject]
        private IServicer _servicer { get; set; } = default!;

        [Inject]
        public IDialogService DialogService { get; set; } = default!;

        private IViewDialog<Credentials> _dialog = default!;


        protected override void OnInitialized()
        {
            _dialog = _servicer.Initialize<AccessDialog<GenericFormDialog<Credentials, AccessValidator>, Credentials>>(DialogService);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
                await ChangingPassword("Changing password");
        }

        private async Task ChangingPassword(string title, string description = "")
        {
            var data = new ViewData<Credentials>(new Credentials(), OperationType.Change, title);
            data.SetVisible("Password", "NewPassword", "RetypedPassword");
            data.Description = description;
            data.Width = "360px";
            data.Width = "360px";

            while (true)
            {
                await _dialog.Show(data);

                var content = _dialog.Content;

                if (content != null)
                {
                    var result = await _access.ChangePassword(new Account() { Credentials = content.Model });

                    if (result.Notes.Status != SigningStatus.InvalidEmail && result.Notes.Status == SigningStatus.ResetPasswordNotConfirmed)
                    {
                        _navigation.NavigateTo("");
                        return;
                    }
                    data.ClearData();
                    data.Info = result.Notes.Info;
                    data.Success = result.Notes.Success;
                    data.Errors = result.Notes.Errors;
                }
                else
                {
                    _navigation.NavigateTo("");
                    return;
                }
            }
        }
    }
}