using Undersoft.SDK.Proxies;

namespace Undersoft.SDK.Service.Application.GUI.View.Generic.Menu
{
    public partial class GenericGrid<TModel> : ViewItem<TModel> where TModel : class, IOrigin, IInnerProxy
    {
        protected override void OnInitialized()
        {
            Data.MapRubrics();


            base.OnInitialized();
        }
    }
}
