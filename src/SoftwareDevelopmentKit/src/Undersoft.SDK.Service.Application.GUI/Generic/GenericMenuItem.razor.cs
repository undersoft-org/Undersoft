using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Service.Application.GUI.View;
using Undersoft.SDK.Uniques;

namespace Undersoft.SDK.Service.Application.GUI.Generic
{
    public partial class GenericMenuItem : ViewBase
    {
        private Type _type = default!;
        private IProxy _proxy = default!;
        private IProxy _childProxy = default!;
        private int _index;
        private string? _name { get; set; } = "";
        private string? _label { get; set; }

        protected override void OnInitialized()
        {
            _type = Rubric.RubricType;
            _proxy = Model.Proxy;
            _index = Rubric.RubricId;
            _name = Rubric.RubricName;
            _label = (Rubric.DisplayName != null) ? Rubric.DisplayName : Rubric.RubricName;
            Id = Rubric.Id.UniqueKey(Parent.Id);
            TypeId = Model.TypeId;
            Rubric.View = this;

            if (Rubric.Expandable)
            {

            }
        }

        public IInnerProxy Model => Data.Model;

        [CascadingParameter]
        public override IViewData Data { get; set; } = default!;

        [Parameter]
        public IViewItem Parent { get; set; } = default!;

        [CascadingParameter]
        public IViewItem Root { get; set; } = default!;

        public IViewRubrics ChildRubrics { get; set; } = default!;

    }
}
