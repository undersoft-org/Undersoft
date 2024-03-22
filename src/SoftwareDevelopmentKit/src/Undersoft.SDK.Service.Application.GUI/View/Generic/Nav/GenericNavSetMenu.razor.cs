using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Service.Application.GUI.View.Abstraction;

namespace Undersoft.SDK.Service.Application.GUI.View.Generic.Nav
{
    public partial class GenericNavSetMenu<TMenu> : ViewItem<TMenu> where TMenu : class, IOrigin, IInnerProxy
    {
        private DotNetObjectReference<GenericNavSetMenu<TMenu>>? _dotNetHelper = null;
        private IJSObjectReference _jsModule = default!;

        [Inject]
        private IJSRuntime JSRuntime { get; set; } = default!;

        protected override void OnInitialized()
        {
            if (Content == null)
                Content = new ViewData<TMenu>(typeof(TMenu).New<TMenu>());

            if (Parent == null)
                Root = this;

            Content.ViewItem = this;

            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>(
                    "import",
                    "./_content/Undersoft.SDK.Service.Application.GUI/Generic/Nav/GenericNav.razor.js"
                );

                _dotNetHelper = DotNetObjectReference.Create(this);

                if (AnchorId is not null)
                {
                    await _jsModule.InvokeVoidAsync("addEventLeftClick", AnchorId, _dotNetHelper);
                }
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        public bool Expanded { get; set; }

        [Parameter]
        public override string? Style { get; set; }

        [Parameter]
        public string AnchorId { get; set; } = default!;

        [Parameter]
        public IViewItem? Parent { get; set; }

        public IViewItem? Root { get; set; }

        [Parameter]
        public string? Margin { get; set; }

        [Parameter]
        public int? Width { get; set; }

        [Parameter]
        public bool Collapsible { get; set; }

        [Parameter]
        public bool CollapseOnOverlayClick { get; set; } = false;

        private async Task HandleExpandCollapseKeyDownAsync(FluentKeyCodeEventArgs args)
        {
            if (args.TargetId != AnchorId)
            {
                return;
            }
            Task handler = args.Key switch
            {
                KeyCode.Enter => ToggleExpandedAsync(),
                KeyCode.Right => SetExpandedAsync(true),
                KeyCode.Left => SetExpandedAsync(false),
                _ => Task.CompletedTask
            };
            await handler;
        }

        private async Task ToggleExpandedAsync() => await Task.FromResult(Expanded = !Expanded);

        private async Task SetExpandedAsync(bool value)
        {
            if (value == Expanded)
            {
                return;
            }

            await Task.FromResult(Expanded = value);
        }

        private async Task CollapseAsync()
        {
            await Task.FromResult(Expanded = false);
        }

        public void Dispose()
        {
            _dotNetHelper?.Dispose();
        }
    }
}
