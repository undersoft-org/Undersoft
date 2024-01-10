using Undersoft.SDK.Uniques;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Undersoft.SDK.Service.Infrastructure.Store.Remote;

using Instant.Rubrics;
using Undersoft.SDK;
using Undersoft.SDK.Service.Client;
using Undersoft.SDK.Service.Infrastructure.Store;

public abstract class RemoteLink<TOrigin, TTarget, TMiddle> : RemoteLink, IRemoteMember<TOrigin, TTarget, TMiddle>
    where TOrigin : class, IOrigin where TTarget : class, IOrigin
{
    public RemoteLink()
    {
        Id = typeof(TTarget).Name.UniqueKey64();
        TypeId = typeof(TOrigin).FullName.UniqueKey32();
        Name = typeof(TOrigin).Name + '_' + typeof(TTarget).Name;

        OpenDataServiceRegistry.Links.Add(TypeId, this);

        OpenDataServiceRegistry.Links.Add(typeof(TTarget).Name.UniqueKey64(TypeId), this);

        ServiceManager.GetManager().Registry.AddObject<IRemoteMember<TOrigin, TTarget>>(this);
    }

    public virtual string Name { get; set; }

    public virtual Expression<Func<TOrigin, object>> SourceKey { get; set; }
    public virtual Expression<Func<TMiddle, object>> MiddleKey { get; set; }
    public virtual Expression<Func<TTarget, object>> TargetKey { get; set; }

    public virtual Func<TOrigin, Expression<Func<TTarget, bool>>> Predicate { get; set; }

    public virtual Expression<Func<TOrigin, IEnumerable<TMiddle>>> MiddleSet { get; set; }

    public abstract Expression<Func<TTarget, bool>> CreatePredicate(object entity);

    public override MemberRubric RemoteRubric => DataStoreRegistry.GetRemoteRubric<TOrigin, TTarget>();

}

public abstract class RemoteLink : Origin, IRemoteLink
{
    protected RemoteLink() { }

    public virtual Towards Towards { get; set; }

    public virtual IUnique Empty => Uscn.Empty;

    public virtual MemberRubric RemoteRubric { get; }
}

public enum Towards
{
    None,
    ToSet,
    ToSingle,
    SetToSet
}
