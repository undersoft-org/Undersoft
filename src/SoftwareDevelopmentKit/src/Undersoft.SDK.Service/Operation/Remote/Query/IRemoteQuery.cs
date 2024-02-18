using System.Linq.Expressions;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Service.Data.Query;


namespace Undersoft.SDK.Service.Operation.Remote.Query;

public interface IRemoteQuery<TDto> : IOperation where TDto : class, IOrigin, IInnerProxy
{
    Expression<Func<TDto, object>>[] Expanders { get; }
    Expression<Func<TDto, bool>> Predicate { get; }
    SortExpression<TDto> Sort { get; }
}