namespace Undersoft.SDK.Service.Infrastructure.Repository;

using Data.Entity;
using Undersoft.SDK;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;

public interface IRepositoryLink<TStore, TOrigin, TTarget> : IRemoteRepository<TStore, TTarget>,
                 IRemoteRelation<TOrigin, TTarget>, IRemoteProperty<TStore, TOrigin>
                 where TOrigin : class, IOrigin, IInnerProxy where TTarget : class, IOrigin, IInnerProxy where TStore : IDataServiceStore
{
}
