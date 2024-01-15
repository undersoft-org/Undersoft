using Microsoft.EntityFrameworkCore;
using Undersoft.SDK.Service.Client;
using Undersoft.SDK.Service.Data.Mapper;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Infrastructure.Repository.Client;
using Undersoft.SDK.Service.Infrastructure.Repository.Source;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SDK.Service.Infrastructure.Repository
{
    public interface IRepositoryManager
    {
        IDataMapper Mapper { get; }

        IRepositoryClient AddClient(IRepositoryClient client);
        void AddClientPool(Type contextType, int poolSize, int minSize = 1);
        Task AddClientPools();
        Task AddEndpointPools();
        IRepositorySource AddSource(IRepositorySource source);
        void AddSourcePool(Type contextType, int poolSize, int minSize = 1);
        IDataMapper CreateMapper(params MapperProfile[] profiles);
        IDataMapper CreateMapper<TProfile>() where TProfile : MapperProfile;
        ValueTask DisposeAsyncCore();
        IRepositoryClient GetClient<TStore, TEntity>() where TEntity : class, IDataObject;
        IEnumerable<IRepositoryClient> GetClients();
        IDataMapper GetMapper();
        IRepositorySource GetSource<TStore, TEntity>() where TEntity : class, IDataObject;
        IEnumerable<IRepositorySource> GetSources();
        IRemoteRepository<TDto> load<TDto>() where TDto : class, IDataObject;
        IRemoteRepository<TDto> Load<TDto>() where TDto : class, IDataObject;
        IRemoteRepository<TDto> Load<TDto>(Type contextType) where TDto : class, IDataObject;
        IRemoteRepository<TDto> load<TStore, TDto>()
            where TStore : IDataServiceStore
            where TDto : class, IDataObject;
        IRemoteRepository<TDto> Load<TStore, TDto>()
            where TStore : IDataServiceStore
            where TDto : class, IDataObject;
        bool TryGetClient(Type contextType, out IRepositoryClient source);
        bool TryGetClient<TContext>(out IRepositoryClient<TContext> source) where TContext : OpenDataServiceContext;
        bool TryGetSource(Type contextType, out IRepositorySource source);
        bool TryGetSource<TContext>(out IRepositorySource<TContext> source) where TContext : DbContext;
        IStoreRepository<TEntity> use<TEntity>() where TEntity : class, IDataObject;
        IStoreRepository<TEntity> Use<TEntity>() where TEntity : class, IDataObject;
        IStoreRepository<TEntity> Use<TEntity>(Type contextType) where TEntity : class, IDataObject;
        IStoreRepository<TEntity> use<TStore, TEntity>()
            where TStore : IDataServerStore
            where TEntity : class, IDataObject;
        IStoreRepository<TEntity> Use<TStore, TEntity>()
            where TStore : IDataServerStore
            where TEntity : class, IDataObject;
    }
}