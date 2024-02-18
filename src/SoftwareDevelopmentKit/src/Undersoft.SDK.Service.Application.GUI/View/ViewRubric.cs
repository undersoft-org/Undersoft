using Microsoft.AspNetCore.Components.Forms;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Series;

namespace Undersoft.SDK.Service.Application.GUI.View;

public class ViewRubric : MemberRubric, IViewRubric
{
    public FieldIdentifier FieldIdentifier { get; set; }

    public ISeries<string> Errors { get; set; } = new Listing<string>();

    public IViewItem View { get; set; } = default!;

    public void RenderView()
    {
        View?.RenderView();
    }

    public ViewRubric ShallowCopy(ViewRubric dst)
    {
        object result = ShalowCopy(dst);
        return (ViewRubric)result;
    }
}

