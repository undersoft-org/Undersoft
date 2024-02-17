using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Service.Application.GUI.View;

namespace Undersoft.SDK.Service.Application.GUI.Generic
{
    public partial class GenericMenu : ViewBase
    {
        private IViewRubrics _rubrics => Data.Rubrics;

        protected override void OnInitialized()
        {
            if (Parent == null)
                Root = this;
        }

        [Parameter]
        public string AnchorId { get; set; } = default!;

        [Parameter]
        public MouseButton Trigger { get; set; } = default!;

        [Parameter]
        public IViewItem? Parent { get; set; }

        public IViewItem? Root { get; set; }

        private void OnMenuChange(MenuChangeEventArgs args)
        {
            if (args is not null && args.Value is not null)
                _ = args.Value;
        }
    }


}