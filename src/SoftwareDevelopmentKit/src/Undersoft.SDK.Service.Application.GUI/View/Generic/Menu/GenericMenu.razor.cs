using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Service.Application.GUI.View.Abstraction;

namespace Undersoft.SDK.Service.Application.GUI.View.Generic.Menu
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
        public HorizontalPosition Position { get; set; } = HorizontalPosition.Right;

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

        public void OnMenuChange(MenuChangeEventArgs args)
        {
        }
    }
}
