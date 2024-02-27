using Microsoft.FluentUI.AspNetCore.Components;
using System.ComponentModel;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Service.Application.GUI.View.Abstraction;
using Undersoft.SDK.Uniques;

namespace Undersoft.SDK.Service.Application.GUI.View
{
    public class ViewItem<TModel> : ViewItem where TModel : class, IOrigin, IInnerProxy
    {
        protected override void OnInitialized()
        {
            if (Data == null)
                GenericData = new ViewData<TModel>(typeof(TModel).New<TModel>());
        }

        public override TModel Model => GenericData.Model;

        [Parameter]
        public virtual IViewData<TModel> GenericData
        {
            get => (IViewData<TModel>)base.Data;
            set => base.Data = value;
        }
    }

    public class ViewItem : ComponentBase, IOrigin, IViewItem
    {
        protected long? typeId;

        protected IOrigin origin = new Origin();

        protected override void OnInitialized()
        {
            if (Data == null)
                Data = typeof(ViewData<>)
                    .MakeGenericType(Model.GetType())
                    .New<IViewData>(Model.GetType().New());
        }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        public virtual long Id
        {
            get => origin.Id;
            set => origin.Id = value;
        }

        public virtual long TypeId
        {
            get => typeId ??= this.GetType().UniqueKey32();
            set => typeId = value;
        }

        public virtual string ViewId => Id.ToString();

        [Parameter]
        public virtual Icon? Icon { get; set; }

        [Parameter]
        public virtual string? Class { get; set; } = "";

        [Parameter]
        public virtual string? Style { get; set; }

        [Parameter]
        public virtual string? Attributes { get; set; }

        public virtual object? Value
        {
            get => Data.Model.Proxy[Rubric.RubricId];
            set => Data.Model.Proxy[Rubric.RubricId] = value;
        }

        public virtual IInnerProxy Model => Data.Model;

        [Parameter]
        public virtual IViewData Data { get; set; } = default!;

        [Parameter]
        public virtual IViewRubric Rubric { get; set; } = default!;

        public object? Reference { get; set; } = default!;

        public string CodeNo
        {
            get => origin.CodeNo;
            set => origin.CodeNo = value;
        }

        public DateTime Created
        {
            get => origin.Created;
            set => origin.Created = value;
        }

        public string Creator
        {
            get => origin.Creator;
            set => origin.Creator = value;
        }

        public DateTime Modified
        {
            get => origin.Modified;
            set => origin.Modified = value;
        }

        public string Modifier
        {
            get => origin.Modifier;
            set => origin.Modifier = value;
        }

        public int OriginId
        {
            get => origin.OriginId;
            set => origin.OriginId = value;
        }

        public virtual string? Label
        {
            get => origin.Label;
            set => origin.Label = value;
        }

        public string TypeName
        {
            get => origin.TypeName;
            set => origin.TypeName = value;
        }

        public DateTime Time
        {
            get => origin.Time;
            set => origin.Time = value;
        }

        public event PropertyChangedEventHandler? PropertyChanged
        {
            add { origin.PropertyChanged += value; }
            remove { origin.PropertyChanged -= value; }
        }

        event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged
        {
            add { origin.PropertyChanged += value; }
            remove { origin.PropertyChanged -= value; }
        }

        public long AutoId()
        {
            return origin.AutoId();
        }

        public void GetFlag(StateFlags state)
        {
            origin.GetFlag(state);
        }

        public byte GetPriority()
        {
            return origin.GetPriority();
        }

        public virtual void RenderView()
        {
            StateHasChanged();
        }

        public void SetFlag(StateFlags state, bool flag)
        {
            origin.SetFlag(state, flag);
        }

        public long SetId(long id)
        {
            return origin.SetId(id);
        }

        public long SetId(object id)
        {
            return origin.SetId(id);
        }

        TEntity IOrigin.Sign<TEntity>(TEntity entity)
        {
            return origin.Sign(entity);
        }

        TEntity IOrigin.Stamp<TEntity>(TEntity entity)
        {
            return origin.Stamp(entity);
        }

    }
}
