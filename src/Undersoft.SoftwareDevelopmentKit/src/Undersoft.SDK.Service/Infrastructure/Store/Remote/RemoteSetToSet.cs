using System.Linq.Expressions;

namespace Undersoft.SDK.Service.Infrastructure.Store.Remote;

using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Relation;
using Uniques;

public class RemoteSetToSet<TOrigin, TTarget> : RemoteRelation<TOrigin, TTarget>
    where TOrigin : class, IOrigin, IInnerProxy
    where TTarget : class, IOrigin, IInnerProxy
{
    private Expression<Func<TTarget, object>> targetKey;
    private Func<IRemoteLink<TOrigin, TTarget>, object> middleKey;
    private Func<TOrigin, IEnumerable<IRemoteLink<TOrigin, TTarget>>> middleSet;

    public RemoteSetToSet() : base() { }

    public RemoteSetToSet(
        Expression<Func<IRemoteLink<TOrigin, TTarget>, object>> middlekey,
        Expression<Func<TTarget, object>> targetkey
    ) : base()
    {
        Towards = Towards.SetToSet;
        MiddleKey = middlekey;
        TargetKey = targetkey;

        middleKey = middlekey.Compile();
        targetKey = targetkey;

        Predicate = (o) => CreatePredicate(o);        
    }

    public override Expression<Func<TTarget, bool>> CreatePredicate(object entity)
    {
        var innerProxy = ((IInnerProxy)entity);
        var nodeRubric = innerProxy.Proxy.Rubrics
            .Where(r => r.RubricType == typeof(IRemoteLink<TOrigin, TTarget>))
            .FirstOrDefault();

        if (nodeRubric == null)
            return null;

        return LinqExtension.GetWhereInExpression(
            TargetKey,
            ((IEnumerable<IRemoteLink<TOrigin, TTarget>>)innerProxy[nodeRubric.RubricId])?.Select(middleKey)
        );
    }
}
