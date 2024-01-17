using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace Undersoft.SDK.Service;

using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Repository.Source.Store;
using Undersoft.SDK.Service.Infrastructure.Store;

public partial class ServiceSetup
{
    public IServiceSetup AddDomainImplementations()
    {
        IServiceRegistry service = registry;        
      
        HashSet<Type> duplicateCheck = new HashSet<Type>();
        Type[] stores = DataStoreRegistry.Stores.Where(s => s.IsAssignableTo(typeof(IDataServerStore))).ToArray();

        service.AddScoped<IRemoteSynchronizer, RemoteSynchronizer>();

        foreach (ISeries<IEntityType> contextEntityTypes in DataStoreRegistry.EntityTypes)
        {
            foreach (IEntityType _entityType in contextEntityTypes)
            {
                Type entityType = _entityType.ClrType;
                if (duplicateCheck.Add(entityType))
                {
                    foreach (Type store in stores)
                    {
                        service.AddScoped(
                            typeof(IStoreRepository<,>).MakeGenericType(store, entityType),
                            typeof(StoreRepository<,>).MakeGenericType(store, entityType));

                        service.AddSingleton(
                            typeof(IEntityCache<,>).MakeGenericType(store, entityType),
                            typeof(EntityCache<,>).MakeGenericType(store, entityType));
                    }
                }
            }
        }
        return this;
    }
}