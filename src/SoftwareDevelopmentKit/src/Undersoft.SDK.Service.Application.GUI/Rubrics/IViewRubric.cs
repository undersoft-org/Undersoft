using Microsoft.AspNetCore.Components.Forms;
using Undersoft.SDK.Instant.Rubrics;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Application.GUI.Generic;

namespace Undersoft.SDK.Service.Application.GUI.Rubrics
{
    public interface IViewRubric : IRubric
    {
        FieldIdentifier FieldIdentifier { get; set; }

        ISeries<string> Errors { get; set; }

        IGenericField GenericField { get; set; }
    }
}