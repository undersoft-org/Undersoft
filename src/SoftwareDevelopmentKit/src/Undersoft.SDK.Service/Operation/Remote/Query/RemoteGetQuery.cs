using System.Linq.Expressions;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Service.Data.Query;

namespace Undersoft.SDK.Service.Operation.Remote.Query;

public class RemoteGetQuery<TStore, TDto, TModel> : RemoteQuery<TStore, TDto, IQueryable<TModel>>
    where TDto : class, IOrigin, IInnerProxy
    where TStore : IDataServiceStore
{
    public RemoteGetQuery(params Expression<Func<TDto, object>>[] expanders) : base(expanders) { }

    public RemoteGetQuery(
        SortExpression<TDto> sortTerms,
        params Expression<Func<TDto, object>>[] expanders
    ) : base(sortTerms, expanders) { }
}
