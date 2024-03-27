using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Application.GUI.View.Abstraction;

namespace Undersoft.SDK.Service.Application.GUI.View.Generic.Nav
{
    public partial class GenericNavMenu<TMenu> : ViewItem<TMenu> where TMenu : class, IOrigin, IInnerProxy
    {
        private DotNetObjectReference<GenericNavMenu<TMenu>>? _dotNetHelper = null;
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

            ChildItems = new Listing<IViewItem>();

            Expanded = true;

            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>(
                    "import",
                    "./_content/Undersoft.SDK.Service.Application.GUI/View/Generic/Nav/GenericNavMenu.razor.js"
                );

                _dotNetHelper = DotNetObjectReference.Create(this);

                if (BindingId is not null)
                {
                    await _jsModule.InvokeVoidAsync("addEventLeftClick", BindingId, _dotNetHelper);
                }
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        public bool Expanded { get; set; }

        [Parameter]
        public bool SingleMenu { get; set; }

        [Parameter]
        public override string? Style { get; set; }

        [Parameter]
        public IViewItem? Parent { get; set; }

        public IViewItem? Root { get; set; }

        [Parameter]
        public string? Margin { get; set; }

        [Parameter]
        public int? Width { get; set; }

        [Parameter]
        public bool Collapsible { get; set; } = true;

        [Parameter]
        public bool CollapseOnOverlayClick { get; set; } = true;

        public async Task HandleExpandCollapseKeyDownAsync(FluentKeyCodeEventArgs args)
        {
            if (args.TargetId != BindingId)
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

        [JSInvokable]
        public async Task ToggleExpandedAsync()
        {
            //if (Expanded)
            //{
            //    ChildItems.Cast<GenericNavItem>().ForEach(c => c.Expanded = false).Commit();
            //}
            await Task.FromResult(Expanded = !Expanded);
            this.RenderView();
        }

        public async Task SetExpandedAsync(bool value)
        {
            if (value == Expanded)
            {
                return;
            }

            await Task.FromResult(Expanded = value);
        }

        public async Task CollapseAsync()
        {
            await Task.FromResult(Expanded = false);
        }

        public void Dispose()
        {
            _dotNetHelper?.Dispose();
        }
    }
}
