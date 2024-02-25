using Microsoft.AspNetCore.Components.Forms;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Series;

namespace Undersoft.SDK.Service.Application.GUI.View.Abstraction
{
    public interface IViewRubric : IRubric, IView
    {
        FieldIdentifier FieldIdentifier { get; set; }

        ISeries<string> Errors { get; set; }

        IViewItem View { get; set; }
    }
}