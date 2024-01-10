using Undersoft.SDK.Instant;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Undersoft.SDK.Service.Infrastructure.Store.Remote;

using Uniques;
using Instant.Rubrics;
using Undersoft.SDK;

public interface IRemoteLink : IUnique
{
    Towards Towards { get; set; }

    MemberRubric RemoteRubric { get; }
}

public interface IRemoteMember<TOrigin, TTarget> : IRemoteLink where TOrigin : class, IOrigin where TTarget : class, IOrigin
{
    Expression<Func<TOrigin, object>> SourceKey { get; set; }
    Expression<Func<TTarget, object>> TargetKey { get; set; }

    Func<TOrigin, Expression<Func<TTarget, bool>>> Predicate { get; set; }

    Expression<Func<TTarget, bool>> CreatePredicate(object entity);
}

public interface IRemoteMember<TOrigin, TTarget, TMiddle> : IRemoteMember<TOrigin, TTarget> where TOrigin : class, IOrigin where TTarget : class, IOrigin
{
    Expression<Func<TMiddle, object>> MiddleKey { get; set; }

    Expression<Func<TOrigin, IEnumerable<TMiddle>>> MiddleSet { get; set; }
}
