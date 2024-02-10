using Microsoft.AspNetCore.Components.Forms;
using Undersoft.SDK.Instant.Rubrics;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Application.GUI.Generic;

namespace Undersoft.SDK.Service.Application.GUI.Rubrics;

public class ViewRubric : MemberRubric, IViewRubric
{
    public FieldIdentifier FieldIdentifier { get; set; }

    public ISeries<string> Errors { get; set; } = new Listing<string>();

    public IGenericField GenericField { get; set; } = default!;

    public ViewRubric ShallowCopy(ViewRubric dst)
    {
        object result = base.ShalowCopy(dst);
        return (ViewRubric)result;
    }
}

