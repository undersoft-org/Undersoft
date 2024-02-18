using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Service.Application.GUI.View;

namespace Undersoft.SDK.Service.Application.GUI.Generic
{
    public partial class GenericMenu : ViewItem
    {
        protected override void OnInitialized()
        {
            Data.MapRubrics();
            if (Parent == null)
                Root = this;
            base.OnInitialized();
        }

        [Parameter]
        public string AnchorId { get; set; } = default!;

        [Parameter]
        public bool Anchored { get; set; } = default!;

        [Parameter]
        public MouseButton Trigger { get; set; } = MouseButton.Left;

        [Parameter]
        public IViewItem? Parent { get; set; }

        public IViewItem? Root { get; set; }

        public void OnMenuChange(MenuChangeEventArgs args)
        {
        }
    }
}
