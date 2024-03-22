using Undersoft.SDK.Service.Application.GUI.View.Abstraction;

namespace Undersoft.SDK.Service.Application.GUI.View.Generic.Nav
{
    public partial class GenericNav : ViewItem
    {
        protected override void OnInitialized()
        {
            Data.MapRubrics();
            if (Parent == null)
                Root = this;

            Data.ViewItem = this;

            base.OnInitialized();
        }

        [Parameter]
        public override string? Style { get; set; }

        [Parameter]
        public IViewItem? Parent { get; set; }

        [CascadingParameter]
        public IViewItem? Root { get; set; }
    }
}
