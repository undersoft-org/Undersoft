using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;
using System.Runtime.CompilerServices;
using Undersoft.SDK.Service.Hosting;
using Undersoft.SDK.Service.Client;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;

namespace Undersoft.SDK.Service.Hosting
{
    public static class ServiceHostRemoteImplementations
    {
        public static void AddOpenDataRemoteImplementations(this IServiceRegistry reg)
        {
            IServiceRegistry service = reg;
            HashSet<Type> duplicateCheck = new HashSet<Type>();
            Type[] stores = new Type[] { typeof(IDataStore) };

            /**************************************** DataService Entity Type Routines ***************************************/
           
            foreach (ISeries<IEdmEntityType> contextEntityTypes in OpenDataRegistry.ContextEntities)
            {
                foreach (IEdmEntityType _entityType in contextEntityTypes)
                {
                    Type entityType = OpenDataRegistry.GetMappedType(_entityType.Name);
                    if (entityType != null && duplicateCheck.Add(entityType))
                    {
                        Type callerType = DataStoreRegistry.GetRemoteType(entityType.Name);
                        if (callerType != null)
                        {
                            Type relationType = typeof(RemoteRelation<,>).MakeGenericType(callerType, entityType);

                            if (OpenDataRegistry.Remotes.TryGet(relationType, out ISeriesItem<RemoteRelation> relation))
                                service.AddObject(typeof(IRemoteRelation<,>).MakeGenericType(callerType, entityType), relation.Value);
                        }

                        stores = OpenDataRegistry.GetEntityStoreTypes(entityType);
                        if (stores != null)
                        {
                            /*****************************************************************************************/
                            foreach (Type store in stores)
                            {

                                /*****************************************************************************************/
                                service.AddScoped(
                                    typeof(IRemoteRepository<,>).MakeGenericType(store, entityType),
                                    typeof(RemoteRepository<,>).MakeGenericType(store, entityType)
                                );

                                service.AddScoped(
                                    typeof(IEntityCache<,>).MakeGenericType(store, entityType),
                                    typeof(EntityCache<,>).MakeGenericType(store, entityType)
                                );
                                /*****************************************************************************************/
                                service.AddScoped(
                                    typeof(IRemoteSet<,>).MakeGenericType(store, entityType),
                                    typeof(RemoteSet<,>).MakeGenericType(store, entityType)
                                );
                                /*****************************************************************************************/
                                if (callerType != null)
                                {
                                    /*********************************************************************************************/
                                    service.AddScoped(
                                        typeof(IRepositoryLink<,,>).MakeGenericType(
                                            store,
                                            callerType,
                                            entityType
                                        ),
                                        typeof(RepositoryLink<,,>).MakeGenericType(
                                            store,
                                            callerType,
                                            entityType
                                        )
                                    );

                                    service.AddScoped(
                                        typeof(IRemoteProperty<,>).MakeGenericType(
                                            store,
                                            callerType
                                        ),
                                        typeof(RepositoryLink<,,>).MakeGenericType(
                                            store,
                                            callerType,
                                            entityType
                                        )
                                    );
                                    /*********************************************************************************************/
                                }
                            }
                        }                        
                    }
                }
            }
            //sm.RebuildProviders();
        }
    }
}
