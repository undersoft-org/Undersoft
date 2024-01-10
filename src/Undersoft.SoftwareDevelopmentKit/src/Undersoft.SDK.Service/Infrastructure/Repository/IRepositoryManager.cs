using Undersoft.SDK.Service.Data.Mapper;

namespace Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Infrastructure.Repository.Client;
using Undersoft.SDK.Service.Infrastructure.Repository.Source;
using Undersoft.SDK.Service.Infrastructure.Store;

public interface IRepositoryManager
{
    IDataMapper Mapper { get; }

    Task AddClientPools();
    Task AddEndpointPools();

    IRemoteRepository<TDto> load<TDto>() where TDto : class, IDataObject;
    IRemoteRepository<TDto> Load<TDto>() where TDto : class, IDataObject;
    IRemoteRepository<TDto> Load<TDto>(Type contextType) where TDto : class, IDataObject;
    IRemoteRepository<TDto> load<TStore, TDto>() where TStore : IDataServiceStore where TDto : class, IDataObject;
    IRemoteRepository<TDto> Load<TStore, TDto>() where TStore : IDataServiceStore where TDto : class, IDataObject;

    IRepositoryClient GetClient<TStore, TEntity>() where TEntity : class, IDataObject;
    IEnumerable<IRepositoryClient> GetClients();
    IRepositorySource GetSource<TStore, TEntity>() where TEntity : class, IDataObject;
    IEnumerable<IRepositorySource> GetSources();
    IStoreRepository<TEntity> use<TEntity>() where TEntity : class, IDataObject;
    IStoreRepository<TEntity> Use<TEntity>() where TEntity : class, IDataObject;
    IStoreRepository<TEntity> Use<TEntity>(Type contextType) where TEntity : class, IDataObject;
    IStoreRepository<TEntity> use<TStore, TEntity>()
        where TStore : IDatabaseStore
        where TEntity : class, IDataObject;
    IStoreRepository<TEntity> Use<TStore, TEntity>()
        where TStore : IDatabaseStore
        where TEntity : class, IDataObject;
}