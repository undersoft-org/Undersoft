using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Instant.Rubrics;
using Undersoft.SDK.Service.Operation.Command;
using Undersoft.SDK.Uniques;

namespace Undersoft.SDK.Service.Application.GUI.Generic;

public class GenericData<TModel> : GenericData, IGenericData<TModel>
    where TModel : class, IOrigin, IInnerProxy
{
    public GenericData()
    {
        Data = typeof(TModel).New<TModel>();
        _proxy = Data.Proxy;
        CommandMode = CommandMode.Any;
    }

    public GenericData(CommandMode mode)
    {
        Data = typeof(TModel).New<TModel>();
        _proxy = Data.Proxy;
        CommandMode = mode;
    }

    public GenericData(TModel data) : this(data, CommandMode.Any) { }

    public GenericData(TModel data, CommandMode mode, string title = "")
    {
        Data = data;
        _proxy = data.Proxy;
        Title = title;
        CommandMode = mode;
    }

    public GenericData(TModel data, CommandMode mode, string title, params string[] displayList) : this(data, mode, title)
    {
        if (displayList != null && displayList.Any())
        {
            SetVisible(displayList);
        }
    }

    public override void ClearData() => Data = typeof(TModel).New<TModel>();

    public new TModel Data { get; set; } = default!;

    public override void SetRequired(params string[] requiredList)
    {
        var rubrics = requiredList.ForEach(r => Data.Proxy.Rubrics[r].ShalowCopy(new MemberRubric())
        );
        rubrics.ForEach(r =>
        {
            r.Required = true;
            r.Visible = true;
            r.Editable = true;
        });
        DisplayRubrics.Put(rubrics);
    }

    public override void SetVisible(params string[] visibleList)
    {
        var rubrics = visibleList.ForEach(r => Data.Proxy.Rubrics[r].ShalowCopy(new MemberRubric())
        );
        rubrics.ForEach(r => r.Visible = true);
        DisplayRubrics.Put(rubrics);
    }

    public override void SetEditable(params string[] editableList)
    {
        var rubrics = editableList.ForEach(r => Data.Proxy.Rubrics[r].ShalowCopy(new MemberRubric())
        );
        rubrics.ForEach(r => r.Editable = true);
        DisplayRubrics.Put(rubrics);
    }

    public override void SetDisplayNames(params DisplayPair[] displayPairList)
    {
        var rubrics = displayPairList.ForEach(d =>
        {
            var rubric = Data.Proxy.Rubrics[d.RubricName].ShalowCopy(new MemberRubric());
            rubric.DisplayName = d.DisplayName;
            rubric.Visible = true;
            return rubric;
        });
        DisplayRubrics.Put(rubrics);
    }
}

public class GenericData : Origin, IGenericData
{
    protected IProxy _proxy;

    public GenericData() { }

    public GenericData(IInnerProxy data) : this(data, CommandMode.Any) { }

    public GenericData(CommandMode mode) { CommandMode = mode; }

    public GenericData(IInnerProxy data, CommandMode mode, string title = "") : this(mode)
    {
        Data = data;
        _proxy = data.Proxy;
        Title = title;
    }

    public GenericData(IInnerProxy data, CommandMode mode, string title, params string[] displayList) : this(mode)
    {
        Data = data;
        _proxy = data.Proxy;
        Title = title;
        if (displayList != null && displayList.Any())
        {
            SetVisible(displayList);
        }
    }

    public object? this[int id]
    {
        get => _proxy[id];
        set => _proxy[id] = value;
    }

    public object? this[string propertyName]
    {
        get => _proxy[propertyName];
        set => _proxy[propertyName] = value;
    }

    public virtual void ClearData() => Data = Data.GetType().New<IInnerProxy>();

    public virtual IInnerProxy Data { get; set; } = default!;

    public string? Title { get; set; } = null;

    public string? Description { get; set; } = null;

    public string? Note { get; set; } = null;

    public string? Info { get; set; }

    public string? Errors { get; set; }

    public string? Success { get; set; }

    public Icon? Icon { get; set; }

    public string? Logo { get; set; } = "img/logo.png";

    public string Height { get; set; } = "380px";

    public string Width { get; set; } = "380px";

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

    public bool IsCanceled { get; set; }

    public bool HaveNext { get; set; }

    public CommandMode CommandMode { get; set; }

    public IRubric SelectedRubric { get; set; } = default!;

    public IRubrics DisplayRubrics { get; set; } = new MemberRubrics();

    public virtual void SetRequired(params string[] requiredList)
    {
        var rubrics = requiredList.ForEach(r => Data.ToProxy().Rubrics[r].ShalowCopy(new MemberRubric())
        );
        rubrics.ForEach(r =>
        {
            r.Required = true;
            r.Visible = true;
            r.Editable = true;
        });
        DisplayRubrics.Put(rubrics);
    }

    public virtual void SetVisible(params string[] visibleList)
    {
        var rubrics = visibleList.ForEach(r => Data.ToProxy().Rubrics[r].ShalowCopy(new MemberRubric())
        );
        rubrics.ForEach(r => r.Visible = true);
        DisplayRubrics.Put(rubrics);
    }

    public virtual void SetEditable(params string[] editableList)
    {
        var rubrics = editableList.ForEach(r => Data.ToProxy().Rubrics[r].ShalowCopy(new MemberRubric())
        );
        rubrics.ForEach(r => r.Editable = true);
        DisplayRubrics.Put(rubrics);
    }

    public virtual void SetDisplayNames(params DisplayPair[] displayPairList)
    {
        var rubrics = displayPairList.ForEach(d =>
        {
            var rubric = Data.ToProxy().Rubrics[d.RubricName].ShalowCopy(new MemberRubric());
            rubric.DisplayName = d.DisplayName;
            rubric.Visible = true;
            return rubric;
        });
        DisplayRubrics.Put(rubrics);
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

