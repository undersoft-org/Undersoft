﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;

namespace Undersoft.SDK.Service.Infrastructure.Store;

using Instant.Proxies;
using Instant.Rubrics;
using Undersoft.SDK;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Repository.Source;
using Uniques;

public static class DataStoreRegistry
{
    public static ISeries<ISeries<PropertyInfo>> EntityProperties = new Registry<ISeries<PropertyInfo>>();
    public static ISeries<MemberRubric[]> RemoteMembers = new Registry<MemberRubric[]>();
    public static ISeries<Type> RemoteTypes = new Registry<Type>(true);
    public static ITypedSeries<ISeries<PropertyInfo[]>> IdentityProperties = new TypedRegistry<ISeries<PropertyInfo[]>>();
    public static ISeries<ISeries<IEntityType>> EntityTypes = new Registry<ISeries<IEntityType>>();
    public static ISeries<ISeries<Type>> Contexts = new Registry<ISeries<Type>>();
    public static ISeries<Type> Stores = new Registry<Type>();
    public static ISeries<SourceProvider> SourceProviders = new Registry<SourceProvider>();

    public static ISeries<PropertyInfo> GetEntityProperties(this IDataStoreContext context)
    {
        var contextType = context.GetType();

        if (!EntityProperties.TryGet(contextType, out ISeries<PropertyInfo> dbSetProperties))
        {
            dbSetProperties = new Registry<PropertyInfo>();

            var properties = context.GetType().GetProperties();

            foreach (var property in properties)
            {
                var setType = property.PropertyType;

                var isDbSet = setType.IsGenericType && typeof(IQueryable<>)
                    .IsAssignableFrom(setType.GetGenericTypeDefinition());

                if (isDbSet)
                {
                    var obj = property.GetValue(context, null);
                    var genType = obj.GetType().GenericTypeArguments.FirstOrDefault();
                    dbSetProperties.Put(genType, property);

                }
            }

            EntityProperties.Put(contextType, dbSetProperties);
        }
        return dbSetProperties;
    }
    public static ISeries<PropertyInfo> GetEntityProperties(Type contextType)
    {
        EntityProperties.TryGet(contextType, out ISeries<PropertyInfo> dbSetProperties);
        return dbSetProperties;
    }

    public static ISeries<IEntityType> GetEntityTypes(this IDataStoreContext context)
    {
        var contextType = context.GetType();

        if (!EntityTypes.TryGet(contextType, out ISeries<IEntityType> dbEntityTypes))
        {
            dbEntityTypes = new Registry<IEntityType>();

            var entityTypes = ((DbContext)context).Model.GetEntityTypes();

            var iface = GetStoreType(contextType);

            foreach (var entityType in entityTypes)
            {
                var clrType = entityType.ClrType;

                if (clrType != null && clrType.GetInterfaces().Contains(typeof(IEntity)))
                {
                    dbEntityTypes.Put(clrType.FullName, entityType);

                    if (!Contexts.TryGet(clrType, out ISeries<Type> dbContext))
                        dbContext = new Registry<Type>();

                    dbContext.Put(iface, contextType);
                    Contexts.Put(clrType, dbContext);
                }
            }
            EntityTypes.Put(contextType, dbEntityTypes);
            context.GetIndentityProperties();
            context.RegisterRemoteMembers();
        }

        return dbEntityTypes;
    }
    public static ISeries<IEntityType> GetEntityTypes(Type contextType)
    {
        EntityTypes.TryGet(contextType, out ISeries<IEntityType> dbEntityTypes);
        return dbEntityTypes;
    }

    public static Type GetRemoteType(string remoteName)
    {
        RemoteTypes.TryGet(remoteName, out Type type);
        return type;
    }

    public static ISeries<MemberRubric[]> RegisterRemoteMembers(this IDataStoreContext context)
    {
        var contextType = context.GetType();

        var entities = context.GetEntityTypes();

        foreach (var entity in entities)
        {
            var remoteProperties = entity.ClrType.GetProperties()
                                        .Where(p => p.CustomAttributes
                                        .Any(a => a.AttributeType == typeof(RemoteAttribute))).ToArray();
            if (remoteProperties.Any())
            {
                var rubrics = entity.ClrType.ToProxy().Rubrics;
                var remoteRubrics = rubrics.ContainsIn(n => n.Name, remoteProperties.Collect(p => p.Name)).ToArray();
                RemoteMembers.Put(entity.ClrType.FullName, remoteRubrics);
                remoteRubrics.ForEach((r) =>
                {
                    Type remoteType = r.RubricType;
                    if (remoteType.IsGenericType)
                    {
                        if (remoteType.IsAssignableTo(typeof(IIdentifiers)))
                            remoteType = remoteType.BaseType;
                        remoteType = remoteType.GetGenericArguments().LastOrDefault();
                    }
                    RemoteTypes.Put(remoteType.FullName, entity.ClrType);
                });
            }
        }

        return RemoteMembers;
    }

    public static Type GetStoreType(this IDataStoreContext context)
    {
        return GetStoreType(context.GetType());
    }

    public static Type GetStoreType(Type contextType)
    {
        if (!Stores.TryGet(contextType, out Type iface))
        {
            var type = contextType.IsGenericType
                ? contextType
                : contextType.BaseType;

            iface = type.GenericTypeArguments
                    .Where(i => i
                    .IsAssignableTo(typeof(IDatabaseStore)))
                    .FirstOrDefault();

            if (iface == null)
                iface = typeof(IDatabaseStore);

            Stores.Put(iface, contextType);
            Stores.Put(contextType, iface);
        }
        return iface;
    }

    public static ISeries<ISeries<PropertyInfo[]>> GetIndentityProperties(this IDataStoreContext context)
    {
        if (!EntityProperties.ContainsKey(context.GetType()))
        {
            var entityTypes = ((DbContext)context).Model.GetEntityTypes();
            foreach (var entityType in entityTypes)
            {
                var dbSetKeys = new Registry<PropertyInfo[]>();
                var type = entityType.ClrType;

                for (int i = 3; i < 12; i += 4)
                {
                    var _i = i;
                    _i *= 11;

                    var idType = (DbIdentityType)_i;

                    PropertyInfo[] ids = null;

                    switch (idType)
                    {
                        case DbIdentityType.PrimaryKey:
                            ids = entityType.GetKeys().Where(k => k.IsPrimaryKey())
                                .SelectMany(k => k.Properties.Select(p => p.PropertyInfo)).ToArray();
                            break;
                        case DbIdentityType.Index:
                            ids = entityType.GetIndexes()
                                .SelectMany(k => k.Properties.Select(p => p.PropertyInfo))
                                .ToArray();
                            break;
                        case DbIdentityType.ForeignKey:
                            ids = entityType.GetForeignKeys()
                                .SelectMany(k => k.Properties.Select(p => p.PropertyInfo))
                                .ToArray();
                            break;
                        default:
                            break;
                    }

                    dbSetKeys.Put((uint)_i, ids);
                }
                IdentityProperties.Put(type, dbSetKeys);
            }
        }
        return IdentityProperties;
    }

    public static PropertyInfo[] GetIdentityProperty(Type entityType, DbIdentityType identityType)
    {
        PropertyInfo[] identity = null;
        GetIndentityProperties(entityType)?.TryGet(identityType, out identity);
        return identity;
    }
    public static PropertyInfo[] GetIdentityProperty(this IUnique entity, DbIdentityType identityType)
    {
        if (IdentityProperties.TryGet(entity.GetType(), out ISeries<PropertyInfo[]> dbSetKeys))
            if (dbSetKeys.TryGet(identityType, out PropertyInfo[] keyProperties))
                return keyProperties;

        return null;
    }

    public static ISeries<PropertyInfo[]> GetIndentityProperties(this IOrigin entity)
    {
        if (IdentityProperties.TryGet(entity.GetType(), out ISeries<PropertyInfo[]> dbSetKeys))
            return dbSetKeys;

        return null;
    }
    public static ISeries<PropertyInfo[]> GetIndentityProperties(this IUnique entity)
    {
        if (IdentityProperties.TryGet(entity.GetType(), out ISeries<PropertyInfo[]> dbSetKeys))
            return dbSetKeys;

        return null;
    }
    public static ISeries<PropertyInfo[]> GetIndentityProperties(Type entityType)
    {
        IdentityProperties.TryGet(entityType, out ISeries<PropertyInfo[]> dbIdentities);
        return dbIdentities;
    }

    public static PropertyInfo GetProperty(this IDataStoreContext context, string entityTypeName)
    {
        return context.GetProperty(Type.GetType(entityTypeName));
    }
    public static PropertyInfo GetProperty(this IDataStoreContext context, Type entityType)
    {
        if (context.GetEntityProperties().TryGet(entityType, out PropertyInfo dbSetProperty))
            return dbSetProperty;
        return null;
    }
    public static PropertyInfo GetProperty<TEntity>(this IDataStoreContext context)
    {
        return context.GetProperty(typeof(TEntity));
    }

    public static IEntityType GetEntityType(this IDataStoreContext context, string entityTypeName)
    {
        if (context.GetEntityTypes().TryGet(entityTypeName, out IEntityType dbEntityType))
            return dbEntityType;
        return null;
    }
    public static IEntityType GetEntityType(this IDataStoreContext context, Type entityType)
    {
        if (context.GetEntityTypes().TryGet(entityType.Name, out IEntityType dbEntityType))
            return dbEntityType;
        return null;
    }
    public static IEntityType GetEntityType<TEntity>(this IDataStoreContext context)
    {
        return context.GetEntityType(typeof(TEntity).Name);
    }

    public static MemberRubric[] GetRemoteMembers(Type entityType)
    {
        if (RemoteMembers.TryGet(entityType.FullName, out MemberRubric[] dbRemote))
            return dbRemote;
        return null;
    }
    public static MemberRubric[] GetRemoteMembers<TOrigin>()
    {
        return GetRemoteMembers(typeof(TOrigin));
    }

    public static MemberRubric GetRemoteMember(Type entityType, Type targetType)
    {
        var remotes = GetRemoteMembers(entityType);
        if (remotes == null)
            return null;
        return remotes.Where(r => r.RubricType.IsGenericType
                            ? r.RubricType.GetGenericArguments().Any(ga => ga.Equals(targetType))
                            : r.RubricType.Equals(targetType)).FirstOrDefault();
    }
    public static MemberRubric GetRemoteRubric<TOrigin, TTarget>()
    {
        return GetRemoteMember(typeof(TOrigin), typeof(TTarget));
    }

    private static MethodInfo ContextSetEntityMethod { get; set; }

    public static object GetEntitySet(this IDataStoreContext context, string entityTypeName)
    {
        var entityType = context.GetEntityType(entityTypeName);
        if (entityType != null)
        {
            var clrType = entityType.ClrType;

            if (clrType != null && clrType.GetInterfaces().Contains(typeof(IEntity)))
            {
                ContextSetEntityMethod ??= context.GetType().GetMethods().Where(m => m.IsGenericMethod &&
                        m.Name == "Set" && !m.GetParameters().Any()).ToArray().FirstOrDefault().MakeGenericMethod(clrType);

                object dbset = ContextSetEntityMethod.Invoke(context, (object[])null);

                return dbset;
            }
        }
        return null;
    }
    public static object GetEntitySet(this IDataStoreContext context, Type entityType)
    {
        return context.GetEntitySet(entityType.Name);
    }

    public static DbSet<TEntity> GetEntitySet<TEntity>(this IDataStoreContext context) where TEntity : class, IUniqueIdentifiable
    {
        var entityType = context.GetEntityType<TEntity>();
        if (entityType != null)
            return (DbSet<TEntity>)context.EntitySet<TEntity>();
        return null;
    }

    public static Type GetContext(Type storeType, Type entityType)
    {
        if (Contexts.TryGet(entityType.Name, out ISeries<Type> dbEntityContext))
        {
            var iface = storeType
                .GetInterfaces()
                .Where(i => i.GetInterfaces()
                    .Contains(typeof(IDatabaseStore))).FirstOrDefault();

            if (iface == null && storeType == typeof(IDatabaseStore))
                iface = typeof(IDatabaseStore);

            if (dbEntityContext.TryGet(storeType, out Type contextType))
                return contextType;
        }

        return null;
    }
    public static Type GetContext<TStore, TEntity>() where TEntity : class, IDataObject
    {
        if (Contexts.TryGet(typeof(TEntity), out ISeries<Type> dbEntityContext))
        {
            var iface = typeof(TStore)
                        .GetInterfaces()
                        .Where(i => i.GetInterfaces()
                            .Contains(typeof(IDatabaseStore))).FirstOrDefault();

            if (iface == null && typeof(TStore) == typeof(IDatabaseStore))
                iface = typeof(IDatabaseStore);

            if (dbEntityContext.TryGet(typeof(TStore), out Type contextType))
                return contextType;
        }

        return null;
    }
    public static Type[] GetContexts<TEntity>() where TEntity : class, IDataObject
    {
        if (Contexts.TryGet(typeof(TEntity), out ISeries<Type> dbEntityContext))
            return dbEntityContext.ToArray();
        return null;
    }

    private static string PrimaryKey(this EntityEntry entry)
    {
        var key = entry.Metadata.FindPrimaryKey();

        var values = new List<object>();
        foreach (var property in key.Properties)
        {
            var value = entry.Property(property.Name).CurrentValue;
            if (value != null)
            {
                values.Add(value);
            }
        }

        return string.Join(",", values);
    }
}

public enum DbIdentityType
{
    NONE = 0,
    PrimaryKey = 33,
    Index = 77,
    ForeignKey = 121
}
