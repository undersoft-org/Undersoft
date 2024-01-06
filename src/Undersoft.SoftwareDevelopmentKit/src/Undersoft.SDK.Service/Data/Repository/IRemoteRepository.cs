﻿using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.OData.Client;
using Undersoft.SDK.Service.Data.Query;
using Undersoft.SDK.Service.Data.Repository.Client.Remote;
using Undersoft.SDK.Service.Data.Repository.Pagination;
using Undersoft.SDK.Service.Data.Service;
using Undersoft.SDK.Uniques;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Undersoft.SDK.Service.Data.Repository;

public interface IRemoteRepository<TStore, TEntity> : IRemoteRepository<TEntity> where TEntity : class, IOrigin
{
}

public interface IRemoteRepository<TEntity> : IRepository<TEntity> where TEntity : class, IOrigin
{
    OpenDataServiceContext Context { get; }

    new DataServiceQuery<TEntity> Query { get; }

    DataServiceQuerySingle<TEntity> FindQuerySingle(params object[] keys);

    DataServiceQuery<TEntity> FindQuery(params object[] keys);

    Task<IEnumerable<TEntity>> FindMany(params object[] keys);

    void SetSecurityToken(string token);

    Task<TEntity> FunctionAsync<TKind>(TKind kind, string httpMethod = "GET") where TKind : Enum;

    Task<TEntity> ActionAsync<TModel, TKind>(TModel payload, TKind kind, string httpMethod = "POST") where TKind : Enum;

    Task<TEntity> ActionAsync<TModel, TKind>(TModel[] payload, TKind kind, string httpMethod = "POST") where TKind : Enum;
}