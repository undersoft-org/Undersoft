using Microsoft.FluentUI.AspNetCore.Components;
using System.ComponentModel;
using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Uniques;

namespace Undersoft.SDK.Service.Application.GUI.View
{
    public class ViewBase<TModel> : ViewBase where TModel : class, IInnerProxy, IOrigin
    {
        [Parameter]
        public new virtual IViewData<TModel> Data { get; set; } = default!;
    }

    public class ViewBase : ComponentBase, IOrigin, IViewItem
    {
        public virtual long Id { get => Rubric.Id; set => Rubric.Id = value; }

        public virtual long TypeId { get => Rubric.TypeId; set => Rubric.TypeId = value; }

        [Parameter]
        public virtual Icon? Icon { get; set; }

        [Parameter]
        public virtual string? Class { get; set; } = "";

        [Parameter]
        public virtual string? Style { get; set; }

        [Parameter]
        public virtual string? Attributes { get; set; }

        public virtual object? Value { get; set; }

        [Parameter]
        public virtual IViewData Data { get; set; } = default!;

        [Parameter]
        public virtual IViewRubric Rubric { get; set; } = default!;

        public virtual string CodeNo { get => Rubric.CodeNo; set => Rubric.CodeNo = value; }

        public virtual DateTime Created { get => Rubric.Created; set => Rubric.Created = value; }

        public virtual string Creator { get => Rubric.Creator; set => Rubric.Creator = value; }

        public virtual DateTime Modified { get => Rubric.Modified; set => Rubric.Modified = value; }

        public virtual string Modifier { get => Rubric.Modifier; set => Rubric.Modifier = value; }

        public virtual int OriginId { get => Rubric.OriginId; set => Rubric.OriginId = value; }

        public virtual string TypeName { get => Rubric.TypeName; set => Rubric.TypeName = value; }

        public virtual DateTime Time { get => Rubric.Time; set => Rubric.Time = value; }

        public virtual string Label { get => Rubric.Label; set => Rubric.Label = value; }

        public virtual event PropertyChangedEventHandler? PropertyChanged
        {
            add
            {
                Rubric.PropertyChanged += value;
            }

            remove
            {
                Rubric.PropertyChanged -= value;
            }
        }

        public virtual void RenderView()
        {
            StateHasChanged();
        }

        public long AutoId()
        {
            return Rubric.AutoId();
        }

        public void GetFlag(StateFlags state)
        {
            Rubric.GetFlag(state);
        }

        public byte GetPriority()
        {
            return Rubric.GetPriority();
        }

        public void SetFlag(StateFlags state, bool flag)
        {
            Rubric.SetFlag(state, flag);
        }

        public long SetId(long id)
        {
            return Rubric.SetId(id);
        }

        public long SetId(object id)
        {
            return Rubric.SetId(id);
        }

        TEntity IOrigin.Sign<TEntity>(TEntity entity)
        {
            return Rubric.Sign(entity);
        }

        TEntity IOrigin.Stamp<TEntity>(TEntity entity)
        {
            return Rubric.Stamp(entity);
        }
    }
}
