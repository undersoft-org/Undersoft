﻿using Microsoft.OData.Client;
using System.Linq.Expressions;
using Undersoft.SDK.Service.Client;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SDK.Service.Infrastructure.Repository;

public interface IRemoteRepository<TStore, TEntity> : IRemoteRepository<TEntity> where TEntity : class, IOrigin, IInnerProxy
{
}

public interface IRemoteRepository<TEntity> : IRepository<TEntity> where TEntity : class, IOrigin, IInnerProxy
{
    OpenDataServiceContext Context { get; }
    string FullName { get; }
    string Name { get; }

    Task<TEntity> ActionAsync<TModel, TKind>(TEntity payload, TKind kind) where TKind : Enum;
    Task<TEntity> ActionAsync<TModel, TKind>(TEntity[] payloads, TKind kind) where TKind : Enum;
    Task<IEnumerable<TEntity>> FindMany(params object[] keys);
    DataServiceQuery<TEntity> FindQuery(params object[] keys);
    DataServiceQuerySingle<TEntity> FindQuerySingle(params object[] keys);
    Task<TEntity> FunctionAsync<TModel, TKind>(TKind kind) where TKind : Enum;
    string KeyString(params object[] keys);
    void SetSecurityToken(string token);
    object TracePatching(object item, string propertyName = null, Type type = null);
}