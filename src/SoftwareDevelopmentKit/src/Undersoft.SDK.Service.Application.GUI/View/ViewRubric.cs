using Microsoft.AspNetCore.Components.Forms;
using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Application.GUI.View.Abstraction;

namespace Undersoft.SDK.Service.Application.GUI.View;

public class ViewRubric : MemberRubric, IViewRubric
{
    public FieldIdentifier FieldIdentifier { get; set; }

    public ISeries<string> Errors { get; set; } = new Listing<string>();

    public IViewItem ViewItem { get; set; } = default!;

    public Icon? Icon { get; set; }

    public void RenderView()
    {
        ViewItem?.RenderView();
    }

    public ViewRubric ShallowCopy(ViewRubric dst)
    {
        object result = ShallowCopy((MemberRubric)dst);
        return (ViewRubric)result;
    }
}

