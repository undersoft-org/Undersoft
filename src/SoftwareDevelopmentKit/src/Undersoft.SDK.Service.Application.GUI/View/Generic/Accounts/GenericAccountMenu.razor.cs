using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Service.Application.Access;
using Undersoft.SDK.Service.Application.GUI.View.Abstraction;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SDK.Service.Application.GUI.View.Generic.Accounts
{
    public partial class GenericAccountMenu : ViewItem
    {
        [Inject]
        private AccessProvider<Account> access { get; set; } = default!;

        [Inject]
        private IServicer servicer { get; set; } = default!;

        [Inject]
        private IDialogService DialogService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            var state = await access.GetAuthenticationStateAsync();

            if (state != null && state.User.Identity != null)
            {
                var _rubrics = Data.Model.Proxy.Rubrics;

                if (!state.User.Identity.IsAuthenticated)
                {
                    _rubrics["Profile"].Visible = false;
                    _rubrics["SignOut"].Visible = false;
                    _rubrics["SignIn"].Visible = true;
                    _rubrics["SignUp"].Visible = true;
                }
                else
                {
                    Data.Model.Proxy[_rubrics["Profile"].RubricId] = servicer.Initialize<
                        ViewPanel<
                            GenericAccountPanel<Account, GenericAccountPanelValidator>,
                            Account
                        >
                    >(DialogService);
                    _rubrics["SignIn"].Visible = false;
                    _rubrics["SignUp"].Visible = false;
                    _rubrics["Profile"].Visible = true;
                    _rubrics["SignOut"].Visible = true;
                }
            }

            Data.MapRubrics();
            if (Parent == null)
                Root = this;
            base.OnInitialized();
        }

        [Parameter]
        public HorizontalPosition Position { get; set; } = HorizontalPosition.Left;

        [Parameter]
        public override string? Style { get; set; }

        [Parameter]
        public string AnchorId { get; set; } = default!;

        [Parameter]
        public bool Anchored { get; set; } = default!;

        [Parameter]
        public MouseButton Trigger { get; set; } = MouseButton.Left;

        [Parameter]
        public IViewItem? Parent { get; set; }

        public IViewItem? Root { get; set; }

        public void OnMenuChange(MenuChangeEventArgs args) { }
    }
}
