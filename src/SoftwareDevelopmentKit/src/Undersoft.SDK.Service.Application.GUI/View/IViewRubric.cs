using Microsoft.AspNetCore.Components.Forms;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Application.GUI.Generic;

namespace Undersoft.SDK.Service.Application.GUI.View
{
    public interface IViewRubric : IRubric, IView
    {
        FieldIdentifier FieldIdentifier { get; set; }

        ISeries<string> Errors { get; set; }

        IViewItem View { get; set; }
    }
}