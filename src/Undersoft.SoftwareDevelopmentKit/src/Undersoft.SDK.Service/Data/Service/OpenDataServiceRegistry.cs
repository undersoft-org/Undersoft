﻿using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.Edm.Csdl;
using System.Xml;

namespace Undersoft.SDK.Service.Data.Service;

using Logging;
using Series;
using Store;
using System.Net;
using Undersoft.SDK;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SDK.Service.Data.Service.Remote;

public static class OpenDataServiceRegistry
{
    const int RECONNECT_INITIAL_COUNT = 30;
    const int RECONNECT_INITIAL_INTERVAL = 6000;
    const int RECONNECT_INTERVAL_LIMIT = 96000;

    public static ISeries<ISeries<IEdmEntityType>> ContextEntities =
        new Registry<ISeries<IEdmEntityType>>();
    public static ISeries<Type> MappedTypes = new Registry<Type>();
    public static ISeries<string> MappedNames = new Registry<string>();
    public static ISeries<string> MappedFullNames = new Registry<string>();
    public static ISeries<ISeries<Type>> EntityContexts = new Registry<ISeries<Type>>();
    public static ISeries<IEdmModel> EdmModels = new Registry<IEdmModel>();
    public static ISeries<Type> Stores = new Registry<Type>();
    public static ISeries<ServiceRemoteBase> Links = new Registry<ServiceRemoteBase>(true);

    public static IEdmModel GetEdmModel(this OpenDataServiceContext context)
    {
        Task<IEdmModel> model = context.GetEdmModelAsync();
        model.Wait();
        return model.Result;
    }

    public static async Task<IEdmModel> GetEdmModelAsync(this OpenDataServiceContext context)
    {
        // Get the service metadata's Uri
        var metadataUri = context.GetMetadataUri();
        // Create a HTTP request to the metadata's Uri
        // in order to get a representation for the data model
        HttpClientHandler clientHandler = new HttpClientHandler();
        using (
            HttpClient client = new HttpClient(clientHandler)
            {
                DefaultRequestVersion = HttpVersion.Version20,
                DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrLower
            }
        )
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                clientHandler.ServerCertificateCustomValidationCallback = (
                    sender,
                    cert,
                    chain,
                    sslPolicyErrors
                ) =>
                {
                    return true;
                };
            }
            int tryouts = RECONNECT_INITIAL_COUNT;
            int interval = RECONNECT_INITIAL_INTERVAL;
            do
            {
                try
                {
                    using (var response = await client.GetAsync(metadataUri))
                    {
                        client.Success<Weblog>("Object Service Client - Connected");

                        if (response.IsSuccessStatusCode)
                        {
                            client.Success<Datalog>("Object Service Client - Metadata Retrieved");
                            // Translate the response into an in-memory stream
                            using (var stream = await response.Content.ReadAsStreamAsync())
                            { // Convert the stream into an XML representation
                                using (var reader = XmlReader.Create(stream))
                                { // Parse the XML representation of the data model
                                    // into an EDM that can be utilized by OData client libraries
                                    return CsdlReader.Parse(reader);
                                }
                            }
                        }
                        else
                        {
                            tryouts--;
                            client.Warning<Weblog>(
                                "Object Service Client - Http Get Metadata Request Failed",
                                response
                            );
                            Thread.Sleep(5000);
                        }
                    }
                }
                catch (Exception ex)
                {
                    tryouts--;
                    client.Warning<Datalog>(
                        "Object Service Client - Http Connection Failed",
                        client.BaseAddress,
                        ex
                    );
                    Thread.Sleep(interval);
                }

                if (tryouts < 2)
                {
                    tryouts = RECONNECT_INITIAL_COUNT;
                    interval =
                        RECONNECT_INTERVAL_LIMIT >= interval * 2
                            ? interval * 2
                            : RECONNECT_INTERVAL_LIMIT;
                }
            } while (tryouts > 0);

            client.Warning<Datalog>(
                "Object Service Client - Retry Connection Limit Exceeded "
                    + "- Unable To Retrieve Metadata From Source",
                client.BaseAddress
            );
        }
        return null;
    }

    public static ISeries<IEdmEntityType> GetEdmEntityTypes(this OpenDataServiceContext context)
    {
        var contextType = context.GetType();

        if (!ContextEntities.TryGet(contextType, out ISeries<IEdmEntityType> dsEntities))
        {
            dsEntities = new Registry<IEdmEntityType>();

            var entityTypes = context
                .GetServiceModel()
                .EntityContainer.EntitySets()
                .Select(p => p.EntityType())
                .ToArray();

            var iface = GetLinkedStoreTypes(contextType);

            foreach (var entityType in entityTypes)
            {
                dsEntities.Add(entityType.Name, entityType);

                var localEntityType = EdmAssemblyResolve(entityType);

                dsEntities.Add(localEntityType.FullName, entityType);

                if (!EntityContexts.TryGet(entityType.Name, out ISeries<Type> dsEntityContext))
                    dsEntityContext = new Registry<Type>();

                dsEntityContext.Put(iface, contextType);
                EntityContexts.Put(entityType.Name, dsEntityContext);
            }
            ContextEntities.Add(contextType, dsEntities);
        }
        return dsEntities;
    }

    public static Type GetLinkedStoreType(this OpenDataServiceContext context)
    {
        return GetLinkedStoreTypes(context.GetType());
    }

    public static Type GetLinkedStoreTypes(Type contextType)
    {
        if (!Stores.TryGet(contextType, out Type iface))
        {
            var type = contextType.IsGenericType ? contextType : contextType.BaseType;

            iface = type.GenericTypeArguments
                .Where(i => i.IsAssignableTo(typeof(IDataServiceStore)))
                .FirstOrDefault();

            if (iface == null)
                iface = typeof(IDataStore);

            Stores.Put(iface, contextType);
            Stores.Put(contextType, iface);
        }
        return iface;
    }

    public static Type GetMappedType(string name)
    {
        string sn = name.Split('.').Last();
        if (MappedTypes.TryGet(name, out Type t) || MappedTypes.TryGet(sn, out t))
            return t;
        return Assemblies.FindType(sn);
    }

    public static Type GetMappedType(this OpenDataServiceContext context, string name)
    {
        return GetMappedType(name);
    }

    public static string GetMappedName(this OpenDataServiceContext context, Type type)
    {
        if (MappedNames.TryGet(type, out string name))
            return name;
        return type.Name;
    }

    public static string GetMappedFullName(this OpenDataServiceContext context, Type type)
    {
        if (MappedFullNames.TryGet(type, out string name))
            return name;
        return type.FullName;
    }

    public static Type GetContextType<TStore, TEntity>() where TEntity : class, IOrigin
    {
        return GetContextType(typeof(TStore), typeof(TEntity));
    }

    public static Type GetContextType(Type storeType, Type entityType)
    {
        if (EntityContexts.TryGet(entityType.Name, out ISeries<Type> dbEntityContext))
        {
            var iface = storeType
                .GetInterfaces()
                .Where(i => i.GetInterfaces().Contains(typeof(IDataServiceStore)))
                .FirstOrDefault();

            if (iface == null && storeType == typeof(IDataStore))
                iface = typeof(IDataStore);

            if (dbEntityContext.TryGet(storeType, out Type contextType))
                return contextType;
        }

        return null;
    }

    public static Type[] GetContextTypes<TEntity>() where TEntity : class, IOrigin
    {
        if (EntityContexts.TryGet(typeof(TEntity).Name, out ISeries<Type> dbEntityContext))
            return dbEntityContext.ToArray();
        return null;
    }

    private static Type EdmAssemblyResolve(IEdmEntityType entityType)
    {
        var remoteName = entityType.Name;
        var remoteFullName = entityType.FullTypeName();
        Type localEntityType = null;
        if (remoteName.Contains("Identifier"))
        {
            var entityName = remoteName.Replace("Identifier", null);
            var argumentType = Assemblies.FindType(entityName);
            localEntityType = typeof(Identifier<>).MakeGenericType(argumentType);
        }
        else
        {
            localEntityType = Assemblies.FindType(remoteName);
        }

        if (localEntityType == null)
            return null;

        MappedTypes.Put(remoteName, localEntityType);
        MappedTypes.Put(remoteFullName, localEntityType);
        MappedNames.Put(localEntityType, remoteName);
        MappedFullNames.Put(localEntityType, remoteFullName);

        return localEntityType;
    }
}
