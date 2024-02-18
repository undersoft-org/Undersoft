﻿using Microsoft.OData.Client;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Service.Data.Client;
using Undersoft.SDK.Service.Data.Repository;

namespace Undersoft.SDK.Service.Data.Remote.Repository;

public interface IRemoteRepository<TStore, TEntity> : IRemoteRepository<TEntity> where TEntity : class, IOrigin, IInnerProxy
{
}

public interface IRemoteRepository<TEntity> : IRepository<TEntity> where TEntity : class, IOrigin, IInnerProxy
{
    OpenDataContext Context { get; }
    string FullName { get; }
    string Name { get; }

    Task<IEnumerable<TEntity>> FindMany(params object[] keys);
    IQueryable<TEntity> FindQuery(params object[] keys);
    DataServiceQuerySingle<TEntity> FindQuerySingle(params object[] keys);

    string KeyString(params object[] keys);
    void SetAuthorizationToken(string token);
    object TracePatching(object item, string propertyName = null, Type type = null);

    Task<TModel> Access<TModel>(string method, TModel args);
    Task<TModel> Action<TModel>(string method, TModel args);
    Task<TModel> Setup<TModel>(string method, TModel args);
}