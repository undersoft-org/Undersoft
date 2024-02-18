using Microsoft.EntityFrameworkCore;
using Undersoft.SDK.Service.Data.Mapper;

namespace Undersoft.SDK.Service.Data.Repository;

using Client;
using Source;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Service.Data.Client;
using Undersoft.SDK.Service.Data.Remote.Repository;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SDK.Service.Data.Store.Repository;

public class RepositoryManager : Registry<IDataStoreContext>, IDisposable, IAsyncDisposable, IRepositoryManager
{
    private new bool disposedValue;
    protected IDataMapper mapper;

    private IRepositorySources _sources;
    protected IRepositorySources Sources => _sources ??= Manager.Registry.GetObject<IRepositorySources>();

    private IRepositoryClients _clients;
    protected IRepositoryClients Clients => _clients ??= Manager.Registry.GetObject<IRepositoryClients>();

    protected IServiceManager Manager { get; init; }

    public IDataMapper Mapper
    {
        get => mapper ??= GetMapper();
    }

    static RepositoryManager()
    {
    }
    public RepositoryManager() : base()
    {
    }

    public IStoreRepository<TEntity> use<TStore, TEntity>() where TEntity : class, IOrigin, IInnerProxy where TStore : IDataServerStore
    {
        return Use<TStore, TEntity>();
    }
    public IStoreRepository<TEntity> use<TEntity>() where TEntity : class, IOrigin, IInnerProxy
    {
        return Use<TEntity>();
    }

    public IStoreRepository<TEntity> Use<TEntity>()
    where TEntity : class, IOrigin, IInnerProxy
    {
        return Use<TEntity>(DataStoreRegistry.GetContexts<TEntity>().FirstOrDefault());
    }
    public IStoreRepository<TEntity> Use<TEntity>(Type contextType)
        where TEntity : class, IOrigin, IInnerProxy
    {
        return (IStoreRepository<TEntity>)Manager.GetService(typeof(IStoreRepository<,>)
                                                 .MakeGenericType(DataStoreRegistry
                                                 .Stores[contextType],
                                                  typeof(TEntity)));
    }
    public IStoreRepository<TEntity> Use<TStore, TEntity>()
       where TEntity : class, IOrigin, IInnerProxy where TStore : IDataServerStore
    {
        return Manager.GetService<IStoreRepository<TStore, TEntity>>();
    }

    public IRemoteRepository<TDto> open<TStore, TDto>() where TDto : class, IOrigin, IInnerProxy where TStore : IDataServiceStore
    {
        return Open<TStore, TDto>();
    }
    public IRemoteRepository<TDto> open<TDto>() where TDto : class, IOrigin, IInnerProxy
    {
        return Open<TDto>();
    }

    public IRemoteRepository<TDto> Open<TDto>() where TDto : class, IOrigin, IInnerProxy
    {
        return Open<TDto>(OpenDataRegistry.GetContextTypes<TDto>().FirstOrDefault());
    }
    public IRemoteRepository<TDto> Open<TDto>(Type contextType)
       where TDto : class, IOrigin, IInnerProxy
    {
        return (IRemoteRepository<TDto>)Manager.GetService(typeof(IRemoteRepository<,>)
                                                 .MakeGenericType(OpenDataRegistry
                                                 .Stores[contextType],
                                                  typeof(TDto)));
    }
    public IRemoteRepository<TDto> Open<TStore, TDto>() where TDto : class, IOrigin, IInnerProxy where TStore : IDataServiceStore
    {
        var result = Manager.GetService<IRemoteRepository<TStore, TDto>>();
        return result;
    }

    public IRepositorySource GetSource<TStore, TEntity>()
    where TEntity : class, IOrigin, IInnerProxy
    {
        var contextType = DataStoreRegistry.GetContext<TStore, TEntity>();
        return Sources.Get(contextType);
    }

    public IRepositoryClient GetClient<TStore, TEntity>()
    where TEntity : class, IOrigin, IInnerProxy
    {
        var contextType = OpenDataRegistry.GetContextType<TStore, TEntity>();

        return Clients.Get(contextType);
    }

    public void AddClientPool(Type contextType, int poolSize, int minSize = 1)
    {
        if (TryGetClient(contextType, out IRepositoryClient client))
        {
            client.PoolSize = poolSize;
            client.CreatePool();
        }
    }

    public Task AddClientPools()
    {
        return Task.Run(() =>
        {
            foreach (var client in GetClients())
            {
                client.CreatePool();
            }
        });
    }

    public static IRepositoryClient CreateClient(IRepositoryClient client)
    {
        Type repotype = typeof(RepositoryClient<>).MakeGenericType(client.ContextType);
        return (IRepositoryClient)repotype.New(client);
    }
    public static IRepositoryClient<TContext> CreateClient<TContext>(IRepositoryClient<TContext> client)
        where TContext : OpenDataContext
    {
        return new RepositoryClient<TContext>(client);
    }
    public static IRepositoryClient<TContext> CreateClient<TContext>(Uri serviceRoot) where TContext : OpenDataContext
    {
        return new RepositoryClient<TContext>(serviceRoot);
    }
    public static IRepositoryClient CreateClient(Type contextType, Uri serviceRoot)
    {
        return new RepositoryClient(contextType, serviceRoot);
    }

    public IRepositoryClient AddClient(IRepositoryClient client)
    {
        Clients.Add(client);
        return client;
    }

    public bool TryGetClient<TContext>(out IRepositoryClient<TContext> source) where TContext : OpenDataContext
    {
        return Clients.TryGet(out source);
    }
    public bool TryGetClient(Type contextType, out IRepositoryClient source)
    {
        return Clients.TryGet(contextType, out source);
    }

    public Task AddEndpointPools()
    {
        return Task.Run(() =>
        {
            foreach (var source in Sources)
            {
                source.CreatePool();
            }
        });
    }

    public void AddSourcePool(Type contextType, int poolSize, int minSize = 1)
    {
        if (TryGetSource(contextType, out IRepositorySource source))
        {
            source.PoolSize = poolSize;
            source.CreatePool();
        }
    }

    public static IRepositorySource<TContext> CreateSource<TContext>(DbContextOptions<TContext> options) where TContext : DbContext, IDataStoreContext
    {
        return new RepositorySource<TContext>(options);
    }
    public static IRepositorySource CreateSource(IRepositorySource source)
    {
        Type repotype = typeof(RepositorySource<>).MakeGenericType(source.ContextType);
        return (IRepositorySource)repotype.New(source);
    }
    public static IRepositorySource<TContext> CreateSource<TContext>(IRepositorySource<TContext> source)
        where TContext : DbContext, IDataStoreContext
    {
        return typeof(RepositorySource<TContext>).New<IRepositorySource<TContext>>(source);
    }
    public static IRepositorySource CreateSource(DbContextOptions options)
    {
        return new RepositorySource(options);
    }

    public IRepositorySource AddSource(IRepositorySource source)
    {
        Sources.Add(source);
        return source;
    }

    public bool TryGetSource<TContext>(out IRepositorySource<TContext> source) where TContext : DbContext
    {
        return Sources.TryGet(out source);
    }
    public bool TryGetSource(Type contextType, out IRepositorySource source)
    {
        return Sources.TryGet(contextType, out source);
    }

    public IEnumerable<IRepositorySource> GetSources()
    {
        return Sources;
    }

    public IEnumerable<IRepositoryClient> GetClients()
    {
        return Clients;
    }

    public IDataMapper CreateMapper(params MapperProfile[] profiles)
    {
        DataMapper.AddProfiles(profiles);
        return Manager.Registry.GetObject<IDataMapper>();
    }
    public IDataMapper CreateMapper<TProfile>() where TProfile : MapperProfile
    {
        DataMapper.AddProfiles(typeof(TProfile).New<TProfile>());
        return Manager.Registry.GetObject<IDataMapper>();
    }

    public IDataMapper GetMapper()
    {
        return Manager.Registry.GetObject<IDataMapper>();
    }

    protected override void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                base.Dispose(true);
            }
            disposedValue = true;
        }
    }

    public override async ValueTask DisposeAsyncCore()
    {
        await base.DisposeAsyncCore().ConfigureAwait(false);
    }
}
