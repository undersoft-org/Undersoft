using System.Linq.Expressions;

namespace Undersoft.SDK.Service.Infrastructure.Store.Remote;

using Microsoft.EntityFrameworkCore.ChangeTracking;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Relation;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Uniques;

public class RemoteSetToSet<TOrigin, TTarget> : RemoteRelation<TOrigin, TTarget>
    where TOrigin : class, IOrigin, IInnerProxy
    where TTarget : class, IOrigin, IInnerProxy
{
    private Expression<Func<TTarget, object>> _targetKey;
    private Func<IRelatedLink<TOrigin, TTarget>, object> _joinKey;
    private Func<TOrigin, IEnumerable<IRelatedLink<TOrigin, TTarget>>> _middleSet;

    public RemoteSetToSet() : base() { }

    public RemoteSetToSet(
        Expression<Func<IRelatedLink<TOrigin, TTarget>, object>> joinKey,
        Expression<Func<TTarget, object>> targetKey
    ) : base()
    {
        Towards = Towards.SetToSet;
        JoinKey = joinKey;
        TargetKey = targetKey;

        _joinKey = joinKey.Compile();
        _targetKey = targetKey;

        Predicate = (o) => CreatePredicate(o);        
    }

    public override Expression<Func<TTarget, bool>> CreatePredicate(object entity)
    {
        var innerProxy = ((IInnerProxy)entity);
        var joinRubric = innerProxy.Proxy.Rubrics
            .Where(r => r.RubricType == typeof(IRelatedLink<TOrigin, TTarget>))
            .FirstOrDefault();

        if (joinRubric == null)
            return null;

        return LinqExtension.GetWhereInExpression(
            TargetKey,
            ((IEnumerable<IRelatedLink<TOrigin, TTarget>>)innerProxy[joinRubric.RubricId])?.Select(_joinKey)
        );
    }
}
