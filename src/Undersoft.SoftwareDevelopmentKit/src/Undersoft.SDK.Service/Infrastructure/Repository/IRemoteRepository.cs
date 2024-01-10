using Microsoft.OData.Client;
using Undersoft.SDK.Service.Client;

namespace Undersoft.SDK.Service.Infrastructure.Repository;

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