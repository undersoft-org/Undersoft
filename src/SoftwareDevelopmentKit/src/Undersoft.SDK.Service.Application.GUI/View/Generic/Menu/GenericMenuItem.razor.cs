using Undersoft.SDK.Proxies;
using Undersoft.SDK.Service.Application.GUI.View.Abstraction;
using Undersoft.SDK.Uniques;

namespace Undersoft.SDK.Service.Application.GUI.View.Generic.Menu
{
    public partial class GenericMenuItem : ViewItem
    {
        [Inject]
        private NavigationManager _navigation { get; set; } = default!;

        private Type _type = default!;
        private IProxy _proxy = default!;
        private IProxy _childProxy = default!;
        private int _index;
        private string? _name { get; set; } = "";
        private string? _label { get; set; }

        [CascadingParameter]
        private bool IsOpen { get; set; }

        protected override void OnInitialized()
        {
            _type = Rubric.RubricType;
            _proxy = Model.Proxy;
            _index = Rubric.RubricId;
            _name = Rubric.RubricName;
            _label = (Rubric.DisplayName != null) ? Rubric.DisplayName : Rubric.RubricName;

            Id = Rubric.Id.UniqueKey(Parent.Id);
            TypeId = _type.UniqueKey(Parent.TypeId);

            Rubric.ViewItem = this;

            if (Rubric.Expandable && _type.IsClass)
            {
                ExpandData = typeof(ViewData<>).MakeGenericType(_type).New<IViewData>(Value);
                ExpandData.MapRubrics();
                if (Parent != null)
                    Parent.Data.Put(ExpandData);
                Root.Data.Put(ExpandData);
            }
        }

        public override object? Value
        {
            get { return _proxy[_index]; }
            set
            {
                _proxy[_index] = value;
            }
        }

        [CascadingParameter]
        public override IViewData Data { get; set; } = default!;

        [Parameter]
        public IViewItem Parent { get; set; } = default!;

        [CascadingParameter]
        public IViewItem Root { get; set; } = default!;

        public IViewData ExpandData { get; set; } = default!;

        public void OnClick()
        {
            if (Rubric.IsLink)
            {
                if (Rubric.LinkValue != null)
                    _navigation.NavigateTo(Rubric.LinkValue);
                if (Rubric.RubricType == typeof(string))
                {
                    var uri = Value?.ToString();
                    if (uri != null)
                        _navigation.NavigateTo(uri);
                }
            }
            if (Rubric.Invoker != null)
            {
                Rubric.Invoker.Invoke(Value);
            }
            IsOpen = false;
        }
    }
}
