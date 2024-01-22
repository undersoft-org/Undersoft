using System.Linq.Expressions;

namespace Undersoft.SDK.Service.Infrastructure.Store.Remote;

using Undersoft.SDK.Service.Data.Relation;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;

public interface IRemoteRelation<TOrigin, TTarget> : IRemoteRelation where TOrigin : class, IOrigin, IInnerProxy where TTarget : class, IOrigin, IInnerProxy
{
    Expression<Func<TOrigin, object>> SourceKey { get; set; }

    Expression<Func<TTarget, object>> TargetKey { get; set; }

    Expression<Func<IRelatedLink<TOrigin, TTarget>, object>> JoinKey { get; set; }

    Expression<Func<TOrigin, IEnumerable<IRelatedLink<TOrigin, TTarget>>>> MiddleSet { get; set; }

    Func<TOrigin, Expression<Func<TTarget, bool>>> Predicate { get; set; }

    Expression<Func<TTarget, bool>> CreatePredicate(object entity);
}

public interface IRemoteRelation : IIdentifiable
{
    Towards Towards { get; set; }

    MemberRubric RemoteRubric { get; }
}
