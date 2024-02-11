using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Service.Application.GUI.View;
using Undersoft.SDK.Service.Operation;
using Undersoft.SDK.Uniques;

namespace Undersoft.SDK.Service.Application.GUI.Generic;

public class ViewData<TModel> : ViewData, IViewData<TModel>
    where TModel : class, IOrigin, IInnerProxy
{
    public ViewData()
    {
        Model = typeof(TModel).New<TModel>();
        _proxy = Model.Proxy;
        CommandMode = OperationType.Any;
    }

    public ViewData(OperationType mode)
    {
        Model = typeof(TModel).New<TModel>();
        _proxy = Model.Proxy;
        CommandMode = mode;
    }

    public ViewData(TModel data) : this(data, OperationType.Any) { }

    public ViewData(TModel data, OperationType mode, string title = "")
    {
        Model = data;
        _proxy = data.Proxy;
        Title = title;
        CommandMode = mode;
    }

    public ViewData(TModel data, OperationType mode, string title, params string[] displayList)
        : this(data, mode, title)
    {
        if (displayList != null && displayList.Any())
        {
            SetVisible(displayList);
        }
    }

    public override void ClearData() => Model = typeof(TModel).New<TModel>();

    public new TModel Model { get; set; } = default!;

    public override void SetRequired(params string[] requiredList)
    {
        var rubrics = requiredList.ForEach(
            r => (ViewRubric)((object)(Model.Proxy.Rubrics[r].ShalowCopy(new ViewRubric())))
        );
        rubrics.ForEach(r =>
        {
            r.Required = true;
            r.Visible = true;
            r.Editable = true;
        });

        ViewRubrics.Put(rubrics);
    }

    public override void SetVisible(params string[] visibleList)
    {
        var rubrics = visibleList.ForEach(
            r => (ViewRubric)((object)(Model.Proxy.Rubrics[r].ShalowCopy(new ViewRubric())))
        );
        rubrics.ForEach(r => r.Visible = true);
        ViewRubrics.Put(rubrics);
    }

    public override void SetEditable(params string[] editableList)
    {
        var rubrics = editableList.ForEach(
            r => (ViewRubric)((object)(Model.Proxy.Rubrics[r].ShalowCopy(new ViewRubric())))
        );
        rubrics.ForEach(r => r.Editable = true);
        ViewRubrics.Put(rubrics);
    }

    public override void SetDisplayNames(params DisplayPair[] displayPairList)
    {
        var rubrics = displayPairList.ForEach(d =>
        {
            var rubric = Model.Proxy.Rubrics[d.RubricName].ShalowCopy(new ViewRubric());
            rubric.DisplayName = d.DisplayName;
            rubric.Visible = true;
            return (ViewRubric)((object)rubric);
        });
        ViewRubrics.Put(rubrics);
    }
}

public class ViewData : Origin, IViewData
{
    protected IProxy _proxy;

    public ViewData() { }

    public ViewData(IInnerProxy data) : this(data, OperationType.Any) { }

    public ViewData(OperationType mode)
    {
        CommandMode = mode;
        _proxy = default!;
    }

    public ViewData(IInnerProxy data, OperationType mode, string title = "") : this(mode)
    {
        Model = data;
        _proxy = data.Proxy;
        Title = title;
    }

    public ViewData(IInnerProxy data, OperationType mode, string title, params string[] displayList)
        : this(mode)
    {
        Model = data;
        _proxy = data.Proxy;
        Title = title;
        if (displayList != null && displayList.Any())
        {
            SetVisible(displayList);
        }
    }

    public virtual void ClearData() => Model = Model.GetType().New<IInnerProxy>();

    public virtual IInnerProxy Model { get; set; } = default!;

    public string? Title { get; set; } = null;

    public string? Description { get; set; } = null;

    public string? Note { get; set; } = null;

    public string? Info { get; set; }

    public string? Errors { get; set; }

    public string? Success { get; set; }

    public Icon? Icon { get; set; }

    public string? Logo { get; set; } = "img/logo.png";

    public string Height { get; set; } = "450px";

    public string Width { get; set; } = "400px";

    private string? nextPath = null;
    public string? NextPath
    {
        get { return nextPath; }
        set
        {
            nextPath = value;
            HaveNext = true;
        }
    }

    public string? NextInvoke { get; set; } = null;

    public bool Canceled { get; set; }

    public bool Selected { get; set; }

    public bool HaveNext { get; set; }

    public OperationType CommandMode { get; set; }

    public IViewRubric SelectedRubric { get; set; } = default!;

    public IViewRubrics ViewRubrics { get; set; } = new ViewRubrics();

    public string? Class { get; set; }

    public IViewValidator Validator { get; set; }

    public virtual void SetRequired(params string[] requiredList)
    {
        var rubrics = requiredList.ForEach(
            r => (ViewRubric)((object)(Model.Proxy.Rubrics[r].ShalowCopy(new ViewRubric())))
        );
        rubrics.ForEach(r =>
        {
            r.Required = true;
            r.Visible = true;
            r.Editable = true;
        });
        ViewRubrics.Put(rubrics);
    }

    public virtual void SetVisible(params string[] visibleList)
    {
        var rubrics = visibleList.ForEach(
            r => (ViewRubric)((object)(Model.Proxy.Rubrics[r].ShalowCopy(new ViewRubric())))
        );
        rubrics.ForEach(r => r.Visible = true);
        ViewRubrics.Put(rubrics);
    }

    public virtual void SetEditable(params string[] editableList)
    {
        var rubrics = editableList.ForEach(
            r => (ViewRubric)((object)(Model.Proxy.Rubrics[r].ShalowCopy(new ViewRubric())))
        );
        rubrics.ForEach(r => r.Editable = true);
        ViewRubrics.Put(rubrics);
    }

    public virtual void SetDisplayNames(params DisplayPair[] displayPairList)
    {
        var rubrics = displayPairList.ForEach(d =>
        {
            var rubric = Model.ToProxy().Rubrics[d.RubricName].ShalowCopy(new ViewRubric());
            rubric.DisplayName = d.DisplayName;
            rubric.Visible = true;
            return (ViewRubric)((object)rubric);
        });
        ViewRubrics.Put(rubrics);
    }

    public IView View { get; set; }

    public void RenderView()
    {
        if (View != null)
            View.RenderView();
        else
            ViewRubrics.ForEach(r => { if (r.View != null) r.View.RenderView(); });
    }

    public void ClearErrors()
    {
        Errors = null;
        ViewRubrics.ForEach(r => r.Errors.Clear());
    }
}

public class DisplayPair : Identifiable
{
    public DisplayPair(string rubricName, string displayName)
    {
        RubricName = rubricName;
        DisplayName = displayName;
        Id = RubricName.UniqueKey32();
    }

    public string RubricName { get; set; }

    public string DisplayName { get; set; }
}
