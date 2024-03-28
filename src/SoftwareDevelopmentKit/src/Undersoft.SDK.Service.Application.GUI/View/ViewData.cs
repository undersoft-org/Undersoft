using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Series.Base;
using Undersoft.SDK.Service.Application.GUI.View.Abstraction;
using Undersoft.SDK.Service.Application.GUI.View.Attributes;
using Undersoft.SDK.Service.Operation;
using Undersoft.SDK.Uniques;

namespace Undersoft.SDK.Service.Application.GUI.View;

public class ViewData<TModel> : ListingBase<IViewData>, IViewData<TModel> where TModel : class, IOrigin, IInnerProxy
{
    protected IProxy _proxy = default!;
    protected IView _view = default!;
    protected long? typeId;

    public ViewData() : this(typeof(TModel).New<TModel>(), OperationType.Any) { }

    public ViewData(OperationType mode) : this(typeof(TModel).New<TModel>(), mode) { }

    public ViewData(TModel data) : this(data, OperationType.Any) { }

    public ViewData(TModel data, OperationType mode, string title = "") : base(true)
    {
        Model = data;
        _proxy = data.Proxy;
        Title = title;
        Operation = mode;
    }

    public virtual void ClearData() => Model = typeof(TModel).New<TModel>();

    public virtual TModel Model { get; set; } = default!;

    public virtual IViewRubrics MapRubrics()
    {
        Rubrics.Put(_proxy.Rubrics.ForOnly(r => r.Visible, r => (ViewRubric)(object)r.ShallowCopy(new ViewRubric())));
        Rubrics.ForEach(r => ViewAttributes.Resolve(r)).Commit();
        Rubrics.ForOnly(r => r.IconMember != null, r => r.Icon = (Icon)_proxy[r.IconMember]).Commit();
        Rubrics.ForOnly(r => r.Icon == null && _proxy.Rubrics.ContainsKey(r.RubricName + "Icon"), r => r.Icon = (Icon)_proxy[r.RubricName + "Icon"]).Commit();
        Rubrics.ForEach((r, x) => r.RubricOrdinal = x).Commit();
        return Rubrics;
    }

    public override long Id { get => Model.Id; set => Model.Id = value; }

    public override long TypeId { get => typeId ??= this.GetType().UniqueKey32(); set => typeId = value; }

    public virtual void SetRequired(params string[] requiredList)
    {
        var rubrics = requiredList.ForEach(
            r => (ViewRubric)(object)_proxy.Rubrics[r].ShallowCopy(new ViewRubric())
        ).Commit();
        rubrics.ForEach((r, x) =>
        {
            r.Required = true;
            r.Visible = true;
            r.Editable = true;
            r.RubricOrdinal = x;
        });

        Rubrics.Put(rubrics);
    }

    public virtual void SetVisible(params string[] visibleList)
    {
        var rubrics = visibleList.ForEach(
            r => (ViewRubric)(object)_proxy.Rubrics[r].ShallowCopy(new ViewRubric())
        ).Commit();
        rubrics.ForEach((r, x) =>
        {
            r.Visible = true;
            r.RubricOrdinal = x;
        });
        Rubrics.Put(rubrics);
    }

    public virtual void SetEditable(params string[] editableList)
    {
        var rubrics = editableList.ForEach(
            r => (ViewRubric)(object)_proxy.Rubrics[r].ShallowCopy(new ViewRubric())
        ).Commit();
        rubrics.ForEach((r, x) =>
        {
            r.Visible = true;
            r.Editable = true;
            r.RubricOrdinal = x;
        });
        Rubrics.Put(rubrics);
    }

    public virtual void SetDisplay(params DisplayPair[] displayPairList)
    {
        var rubrics = displayPairList.ForEach((d, x) =>
        {
            var rubric = _proxy.Rubrics[d.RubricName].ShallowCopy(new ViewRubric());
            rubric.DisplayName = d.DisplayName;
            rubric.Visible = true;
            rubric.RubricOrdinal = x;
            return (ViewRubric)(object)rubric;
        }).Commit();
        Rubrics.Put(rubrics);
    }

    public string ViewId => Id.ToString();

    public bool IsSingle => Count == 0;

    public string? Title { get; set; } = null;

    public string? Description { get; set; } = null;

    public Icon? Icon { get; set; }

    public Icon? Logo { get; set; }

    public string Height { get; set; } = "400px";

    public string Width { get; set; } = "360px";

    public string? Href { get; set; }

    public OperationNotes Notes { get; set; } = new OperationNotes();

    public HorizontalAlignment HorizontalAlignment { get; set; }

    public ViewDelegates Delegates { get; set; } = new ViewDelegates();

    public ViewInvokers Invokers { get; set; } = new ViewInvokers();

    private string? nextHref = null;
    public string? NextHref
    {
        get { return nextHref; }
        set
        {
            nextHref = value;
            HaveNext = true;
        }
    }

    public bool Canceled { get; set; }

    public bool Checked { get; set; }

    public bool HaveNext { get; set; }

    public OperationType Operation { get; set; }

    public IViewRubric ActiveRubric { get; set; } = default!;

    public IViewRubrics Rubrics { get; set; } = new ViewRubrics();

    public string? Class { get; set; }

    public IViewValidator Validator { get; set; } = default!;

    public IView? View
    {
        get => _view;
        set
        {
            if (value != null)
            {
                if (ViewTypeName == null)
                    ViewTypeName = value.GetType().FullName;
                _view = value;
            }
        }
    }

    public string? ViewTypeName { get; set; }

    IInnerProxy IViewData.Model { get => Model; set => Model = (TModel)value; }

    public void RenderView()
    {
        if (View != null)
            View.RenderView();
        else
            Rubrics.ForEach(r => { if (r.ViewItem != null) r.ViewItem.RenderView(); });
    }

    public void ClearErrors()
    {
        Notes.Errors = null;
        Rubrics.ForEach(r => r.Errors.Clear());
    }

    public IViewItem? ViewItem { get; set; }
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
