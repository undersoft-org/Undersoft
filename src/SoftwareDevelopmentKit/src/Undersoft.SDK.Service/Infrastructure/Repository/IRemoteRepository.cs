using Microsoft.OData.Client;
using System.Linq.Expressions;
using Undersoft.SDK.Service.Client;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SDK.Service.Infrastructure.Repository;

public interface IRemoteRepository<TStore, TEntity> : IRemoteRepository<TEntity> where TEntity : class, IOrigin, IInnerProxy
{
}

public interface IRemoteRepository<TEntity> : IRepository<TEntity> where TEntity : class, IOrigin, IInnerProxy
{
    OpenDataContext Context { get; }
    string FullName { get; }
    string Name { get; }
    
    Task<IEnumerable<TEntity>> FindMany(params object[] keys);
    DataServiceQuery<TEntity> FindQuery(params object[] keys); 
    DataServiceQuerySingle<TEntity> FindQuerySingle(params object[] keys);
   
    string KeyString(params object[] keys);
    void SetSecurityToken(string token);
    object TracePatching(object item, string propertyName = null, Type type = null);

    Task<TEntity> Function(string method, Argument argument);
    Task<TEntity> Action(string method, Arguments arguments);

    Task<TEntity> Function<TService>(Expression<Func<TService, Delegate>> method, Argument argument);
    Task<TEntity> Action<TService>(Expression<Func<TService, Delegate>> method, Argument argument);
    Task<TEntity> Action<TService>(Expression<Func<TService, Delegate>> method, Arguments arguments);
}