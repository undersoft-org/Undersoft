﻿using Undersoft.SDK.Service.Client;

namespace Undersoft.SDK.Service.Infrastructure.Repository.Client
{
    public interface IRepositoryClients : ISeries<IRepositoryClient>
    {
        IRepositoryClient this[OpenDataContext context] { get; set; }
        IRepositoryClient this[string contextName] { get; set; }
        IRepositoryClient this[Type contextType] { get; set; }

        void Add(IRepositoryClient repoSource);
        IRepositoryClient<TContext> Add<TContext>(IRepositoryClient<TContext> repoSource) where TContext : OpenDataContext;
        IRepositoryClient Get(Type contextType);
        IRepositoryClient<TContext> Get<TContext>() where TContext : OpenDataContext;
        long GetKey(IRepositoryClient item);
        IRepositoryClient New(Type contextType, Uri route);
        IRepositoryClient<TContext> New<TContext>(Uri route) where TContext : OpenDataContext;
        int PoolCount(Type contextType);
        int PoolCount<TContext>() where TContext : OpenDataContext;
        IRepositoryClient<TContext> Put<TContext>(IRepositoryClient<TContext> repoSource) where TContext : OpenDataContext;
        bool Remove<TContext>() where TContext : OpenDataContext;
        bool TryAdd(IRepositoryClient repoSource);
        bool TryAdd(Type contextType, IRepositoryClient repoSource);
        bool TryAdd<TContext>(IRepositoryClient<TContext> repoSource) where TContext : OpenDataContext;
        bool TryGet(Type contextType, out IRepositoryClient repoSource);
        bool TryGet<TContext>(out IRepositoryClient<TContext> repoSource) where TContext : OpenDataContext;
    }
}