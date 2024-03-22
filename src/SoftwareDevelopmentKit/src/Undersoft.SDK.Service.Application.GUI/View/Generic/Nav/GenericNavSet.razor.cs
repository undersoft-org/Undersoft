using FluentValidation;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Service.Application.GUI.View.Abstraction;

namespace Undersoft.SDK.Service.Application.GUI.View.Generic.Nav
{
    public partial class GenericNavSet<TMenu> : ViewItem<TMenu> where TMenu : class, IOrigin, IInnerProxy
    {
        public bool IsSingle => Data.Rubrics.Count < 2;

        [Parameter]
        public override string? Style { get; set; }

        [Parameter]
        public IViewItem? Parent { get; set; }

        [CascadingParameter]
        public IViewItem? Root { get; set; }

        public string ActiveId
        {
            get => Data.ActiveRubric.RubricName;
            set => Data.ActiveRubric = Content.Rubrics[value];
        }

        protected override void OnParametersSet()
        {
            if (Content == null)
                Content = new ViewData<TMenu>(typeof(TMenu).New<TMenu>());

            Content.MapRubrics();
            Content.Rubrics.ForEach(r =>
                {
                    Model.Proxy[r.RubricId] = r.RubricType.New();
                    if (r.DisplayName == null)
                        r.DisplayName = r.RubricName;
                });
            Data.Put(Data.Rubrics.ForEach(r => typeof(ViewData<>).MakeGenericType(r.RubricType).New<IViewData>(Model.Proxy[r.RubricId])));

            var firstRubric = Data.Rubrics.FirstOrDefault();
            if (firstRubric != null)
                Data.ActiveRubric = firstRubric;

            base.OnParametersSet();
        }
    }
}