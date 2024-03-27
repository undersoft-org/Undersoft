using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Proxies;

namespace Undersoft.SDK.Service.Application.GUI.View.Generic.Nav
{
    public partial class GenericNavExpander<TMenu> : ViewItem<TMenu> where TMenu : class, IOrigin, IInnerProxy
    {
        [Parameter]
        public bool ShowLabel { get; set; }

        [Parameter]
        public override string? Label { get; set; } = typeof(TMenu).Name;

        [Parameter]
        public override Icon? Icon { get; set; } = new Icons.Regular.Size20.Navigation();
    }
}