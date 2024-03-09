using FluentValidation;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Service.Application.GUI.View.Abstraction;

namespace Undersoft.SDK.Service.Application.GUI.View.Generic.Menu
{
    public partial class GenericMenuSet<TMenu> : ViewItem<TMenu> where TMenu : class, IOrigin, IInnerProxy
    {
        public bool IsSingle => Data.Rubrics.Count < 2;

        [Parameter]
        public bool ShowLabels { get; set; } = false;

        [Parameter]
        public bool ShowIcon { get; set; } = true;

        protected override void OnParametersSet()
        {
            if (Data == null)
                Data = new ViewData<TMenu>(typeof(TMenu).New<TMenu>());

            Data.MapRubrics();
            Data.Rubrics.ForEach(r =>
                {
                    Model.Proxy[r.RubricId] = r.RubricType.New();
                    if (r.DisplayName == null)
                        r.DisplayName = r.RubricName;
                });
            Data.Put(Data.Rubrics.ForEach(r => typeof(ViewData<>).MakeGenericType(r.RubricType).New<IViewData>(Model.Proxy[r.RubricId])));

            base.OnParametersSet();
        }
    }
}