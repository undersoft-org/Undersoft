using Microsoft.AspNetCore.Components.Forms;
using Undersoft.SDK.Instant.Rubrics;
using Undersoft.SDK.Series;

namespace Undersoft.SDK.Service.Application.GUI.View
{
    public interface IViewRubric : IRubric
    {
        FieldIdentifier FieldIdentifier { get; set; }

        ISeries<string> Errors { get; set; }

        IViewField Field { get; set; }
    }
}