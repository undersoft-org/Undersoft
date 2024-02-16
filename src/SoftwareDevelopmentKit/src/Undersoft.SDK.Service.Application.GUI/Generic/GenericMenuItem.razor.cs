using Microsoft.AspNetCore.Components.Forms;
using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Service.Application.GUI.View;

namespace Undersoft.SDK.Service.Application.GUI.Generic
{
    public partial class GenericMenuItem<TModel, TMenu> : ComponentBase, IIdentifiable, IViewItem where TMenu : class, IOrigin, IInnerProxy where TModel : class, IOrigin, IInnerProxy
    {
        private Type _type = default!;
        private IProxy _proxy = default!;
        private int _index;
        private string? _name { get; set; } = "";
        private string? _label { get; set; }

        protected override void OnInitialized()
        {
            _type = Rubric.RubricType;
            _proxy = DataModel.Proxy;
            _index = Rubric.RubricId;
            _name = Rubric.RubricName;
            _label = (Rubric.DisplayName != null) ? Rubric.DisplayName : Rubric.RubricName;
            Id = Rubric.Id;
            TypeId = DataModel.TypeId;
            Rubric.FieldIdentifier = new FieldIdentifier(this, _name);
            Rubric.View = this;
        }

        public long Id { get; set; }

        public long TypeId { get; set; }

        public string? Label { get => _label; set { _label = value; } }

        public Icon? Icon { get; set; }

        public string? Class { get; set; } = "";

        public string? Style { get; set; }

        public string? Attributes { get; set; }

        public TModel DataModel => Content.Model;

        public TMenu MenuModel => Menu.Model;

        [CascadingParameter]
        public IViewData<TModel> Content { get; set; } = default!;

        [CascadingParameter]
        public IViewData<TMenu> Menu { get; set; } = default!;

        public object? Value
        {
            get { return _proxy[_index]; }
            set
            {
                _proxy[_index] = value;
            }
        }

        [Parameter]
        public IViewRubric Rubric { get; set; } = default!;

        public void RenderView()
        {
            this.StateHasChanged();
        }

    }



}
