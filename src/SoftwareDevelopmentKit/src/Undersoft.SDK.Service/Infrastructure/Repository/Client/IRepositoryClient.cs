using Undersoft.SDK.Uniques;
using System;
using Microsoft.OData.Edm;
using Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Client;

namespace Undersoft.SDK.Service.Infrastructure.Repository.Client;

public interface IRepositoryClient
    : IRepositoryContextPool,
        IUnique,
        IDisposable,
        IAsyncDisposable
{
    OpenDataServiceContext Context { get; }
    bool Pooled { get; }
    Uri Route { get; }

    Task<IEdmModel> BuildMetadata();
    object CreateContext(Type contextType, Uri serviceRoot);
    TContext CreateContext<TContext>(Uri serviceRoot) where TContext : OpenDataServiceContext;
    void CreatePool<TContext>();
    TContext GetContext<TContext>() where TContext : OpenDataServiceContext;
}

public interface IRepositoryClient<TContext>
    : IRepositoryContextPool<TContext>,
        IRepositoryClient where TContext : class
{
    new TContext Context { get; }

    TContext CreateContext(Uri serviceRoot);
}
