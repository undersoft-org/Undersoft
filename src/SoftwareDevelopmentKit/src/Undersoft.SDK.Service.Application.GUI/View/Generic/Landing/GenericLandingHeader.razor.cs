using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Service.Application.GUI.View.Models;

namespace Undersoft.SDK.Service.Application.GUI.View.Generic.Landing
{
    public partial class GenericLandingHeader<TModel, TAccount> : FluentComponentBase
    {
        [CascadingParameter]
        public AppearanceState? AppearanceState { get; set; } = default!;
    }
}
