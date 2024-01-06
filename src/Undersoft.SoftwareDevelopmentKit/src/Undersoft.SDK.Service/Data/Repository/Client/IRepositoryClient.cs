using Undersoft.SDK.Service.Data.Repository;
using Undersoft.SDK.Service.Data.Service;
using Undersoft.SDK.Uniques;
using System;
using Microsoft.OData.Edm;

namespace Undersoft.SDK.Service.Data.Repository.Client;

public interface IRepositoryClient
    : IRepositoryContextPool,
        IUnique,
        IDisposable,
        IAsyncDisposable
{
    OpenDataServiceContext Context { get; }

    Uri Route { get; }

    TContext GetContext<TContext>() where TContext : OpenDataServiceContext;

    object CreateContext(Type contextType, Uri serviceRoot);
    TContext CreateContext<TContext>(Uri serviceRoot) where TContext : OpenDataServiceContext;

    Task<IEdmModel> BuildMetadata();
}

public interface IRepositoryClient<TContext>
    : IRepositoryContextPool<TContext>,
        IRepositoryClient where TContext : class
{
    new TContext Context { get; }

    TContext CreateContext(Uri serviceRoot);
}
