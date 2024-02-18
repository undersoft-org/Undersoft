
using Undersoft.SDK.Uniques;
using System.Linq.Expressions;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SDK.Proxies;

namespace Undersoft.SDK.Service.Operation.Remote.Query;

public class RemoteFindQuery<TStore, TDto, TModel> : RemoteQuery<TStore, TDto, IQueryable<TModel>>
    where TDto : class, IOrigin, IInnerProxy
    where TStore : IDataServiceStore
    where TModel : class, IIdentifiable
{
    public RemoteFindQuery(params object[] keys) : base(keys) { }

    public RemoteFindQuery(object[] keys, params Expression<Func<TDto, object>>[] expanders)
        : base(keys, expanders) { }

    public RemoteFindQuery(Expression<Func<TDto, bool>> predicate) : base(predicate) { }

    public RemoteFindQuery(
        Expression<Func<TDto, bool>> predicate,
        params Expression<Func<TDto, object>>[] expanders
    ) : base(predicate, expanders) { }
}
