using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Service.Application.GUI.Models;

namespace Undersoft.SDK.Service.Application.GUI.Generic
{
    public partial class GenericLandingHeader<TModel> : FluentComponentBase
    {
        [CascadingParameter]
        public AppearanceState? AppearanceState { get; set; } = default!;
    }
}
