using Undersoft.SDK.Series;
using System;
using Undersoft.SDK.Service.Client;

namespace Undersoft.SDK.Service.Infrastructure.Repository.Client
{
    public interface IRepositoryClients : ISeries<IRepositoryClient>
    {
        IRepositoryClient this[OpenDataServiceContext context] { get; set; }
        IRepositoryClient this[string contextName] { get; set; }
        IRepositoryClient this[Type contextType] { get; set; }

        IRepositoryClient<TContext> Add<TContext>(IRepositoryClient<TContext> repoSource) where TContext : OpenDataServiceContext;
        IRepositoryClient Get(Type contextType);
        IRepositoryClient<TContext> Get<TContext>() where TContext : OpenDataServiceContext;
        long GetKey(IRepositoryClient item);
        IRepositoryClient New(Type contextType, Uri route);
        IRepositoryClient<TContext> New<TContext>(Uri route) where TContext : OpenDataServiceContext;
        IRepositoryClient<TContext> Put<TContext>(IRepositoryClient<TContext> repoSource) where TContext : OpenDataServiceContext;
        bool Remove<TContext>() where TContext : OpenDataServiceContext;
        bool TryAdd(Type contextType, IRepositoryClient repoSource);
        bool TryAdd<TContext>(IRepositoryClient<TContext> repoSource) where TContext : OpenDataServiceContext;
        bool TryGet(Type contextType, out IRepositoryClient repoSource);
        bool TryGet<TContext>(out IRepositoryClient<TContext> repoSource) where TContext : OpenDataServiceContext;
    }
}