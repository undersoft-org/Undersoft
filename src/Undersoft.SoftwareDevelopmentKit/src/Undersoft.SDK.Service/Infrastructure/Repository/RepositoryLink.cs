using Microsoft.OData.Client;
using System.Linq.Expressions;

namespace Undersoft.SDK.Service.Infrastructure.Repository;

using Data.Entity;
using Instant.Rubrics;
using Undersoft.SDK.Service.Client;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Relation;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;

public class RepositoryLink<TStore, TOrigin, TTarget> : RemoteRepository<TStore, TTarget>, IRepositoryLink<TStore, TOrigin, TTarget>
    where TOrigin : class, IDataObject
    where TTarget : class, IDataObject
    where TStore : IDataServiceStore
{
    IRemoteRelation<TOrigin, TTarget> relation;

    public RepositoryLink(
        IRepositoryContextPool<OpenDataService<TStore>> pool,
        IEntityCache<TStore, TTarget> cache,
        IRemoteRelation<TOrigin, TTarget> relation,
        IRemoteSynchronizer synchronizer) : base(pool, cache)
    {
        this.relation = relation;
        Synchronizer = synchronizer;        
    }

    public Expression<Func<TTarget, bool>> CreatePredicate(object entity)
    { return relation.CreatePredicate(entity); }

    public void Load(object origin) { Load(origin, dsContext); }

    public void Load<T>(IEnumerable<T> origins, OpenDataServiceContext context) where T : class
    { origins.ForEach((o) => Load(o, context)); }

    public void Load(object origin, OpenDataServiceContext context)
    {
        IInnerProxy _entity = (IInnerProxy)origin;
        int rubricId = RemoteRubric.RubricId;

        Expression<Func<TTarget, bool>> predicate = CreatePredicate(origin);
        if (predicate != null)
        {
            IRemoteSet<TTarget> remote;
            switch (Towards)
            {
                case Towards.ToSingle:
                    DataServiceQuery<TTarget> query = context.CreateQuery<TTarget>(typeof(TTarget).Name);
                    Synchronizer.AcquireLinker();
                    _entity[rubricId] = query.FirstOrDefault(predicate);
                    Synchronizer.ReleaseLinker();
                    break;
                case Towards.ToSet:
                    remote = new RemoteSet<TTarget>(context);
                    remote.LoadCompleted += Synchronizer.OnLinked;
                    _entity[rubricId] = remote;
                    remote.LoadAsync(predicate);
                    Synchronizer.AcquireLinker();
                    break;
                case Towards.SetToSet:
                    remote = new RemoteSet<TTarget>(context);
                    remote.LoadCompleted += Synchronizer.OnLinked;
                    _entity[rubricId] = remote;
                    remote.LoadAsync(predicate);
                    Synchronizer.AcquireLinker();
                    break;
                default:
                    break;
            }
        }
    }

    public async Task LoadAsync(object origin) { await Task.Run(() => Load(origin, dsContext), Cancellation); }

    public async ValueTask LoadAsync(object origin, OpenDataServiceContext context, CancellationToken token)
    { await Task.Run(() => Load(origin, context), token); }

    public override Task<int> Save(bool asTransaction, CancellationToken token = default)
    { return ContextLease.Save(asTransaction, token); }

    public IRepository Host { get; set; }

    public bool IsLinked { get; set; }

    public override int LinkedCount { get; set; }

    public MemberRubric RemoteRubric => relation.RemoteRubric;

    public Expression<Func<TOrigin, object>> SourceKey
    {
        get => relation.SourceKey;
        set => relation.SourceKey = value;
    }

    public Func<TOrigin, Expression<Func<TTarget, bool>>> Predicate
    {
        get => relation.Predicate;
        set => relation.Predicate = value;
    }

    public IRemoteSynchronizer Synchronizer { get; }

    public Expression<Func<TTarget, object>> TargetKey
    {
        get => relation.TargetKey;
        set => relation.TargetKey = value;
    }

    public override Towards Towards => relation.Towards;

    public Expression<Func<IRemoteLink<TOrigin, TTarget>, object>> MiddleKey 
    { 
        get => relation.MiddleKey;
        set => relation.MiddleKey = value;
    }
    public Expression<Func<TOrigin, IEnumerable<IRemoteLink<TOrigin, TTarget>>>> MiddleSet
    {
        get => relation.MiddleSet;
        set => relation.MiddleSet = value;
    }
}
