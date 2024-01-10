namespace Undersoft.SDK.Service.Infrastructure.Repository;

using Data.Entity;
using Undersoft.SDK;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;

public interface IRepositoryLink<TStore, TOrigin, TTarget> : IRemoteRepository<TStore, TTarget>,
                 IRemoteMember<TOrigin, TTarget>, IRemoteObject<TStore, TOrigin>
                 where TOrigin : class, IOrigin where TTarget : class, IOrigin where TStore : IDataServiceStore
{
}
