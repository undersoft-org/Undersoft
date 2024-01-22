using Undersoft.SDK.Uniques;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Undersoft.SDK.Service.Infrastructure.Store.Remote;

using Instant.Rubrics;
using Undersoft.SDK;
using Undersoft.SDK.Service.Client;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Relation;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;

public abstract class RemoteRelation<TOrigin, TTarget> : RemoteRelation, IRemoteRelation<TOrigin, TTarget>
    where TOrigin : class, IOrigin, IInnerProxy where TTarget : class, IOrigin, IInnerProxy
{
    public RemoteRelation()
    {
        Name = typeof(TOrigin).Name + '_' + typeof(TTarget).Name;
        Id = Name.UniqueKey();

        OpenDataRegistry.Remotes.Add(TypeId, this);
        OpenDataRegistry.Remotes.Add(typeof(TOrigin).FullName.UniqueKey32(), this);
    }

    public virtual string Name { get; set; }

    public virtual Expression<Func<TOrigin, object>> SourceKey { get; set; }
    public virtual Expression<Func<IRelatedLink<TOrigin, TTarget>, object>> JoinKey { get; set; }
    public virtual Expression<Func<TTarget, object>> TargetKey { get; set; }

    public virtual Func<TOrigin, Expression<Func<TTarget, bool>>> Predicate { get; set; }

    public virtual Expression<Func<TOrigin, IEnumerable<IRelatedLink<TOrigin, TTarget>>>> MiddleSet { get; set; }

    public abstract Expression<Func<TTarget, bool>> CreatePredicate(object entity);

    public override MemberRubric RemoteRubric => DataStoreRegistry.GetRemoteRubric<TOrigin, TTarget>();

}

public abstract class RemoteRelation : Origin, IRemoteRelation
{
    protected RemoteRelation() { }

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
