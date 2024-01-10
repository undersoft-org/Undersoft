using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Undersoft.SDK.Service.Server.Operation.Notification;

using Command;


using Undersoft.SDK.Service.Infrastructure.Store;

public class Upserted<TStore, TEntity, TDto> : Notification<Command<TDto>>
    where TDto : class, IDataObject
    where TEntity : class, IDataObject
    where TStore : IDatabaseStore
{
    [JsonIgnore]
    public Func<TEntity, Expression<Func<TEntity, bool>>> Predicate { get; }

    [JsonIgnore]
    public Func<TEntity, Expression<Func<TEntity, bool>>>[] Conditions { get; }

    public Upserted(Upsert<TStore, TEntity, TDto> command) : base(command)
    {
        Conditions = command.Conditions;
        Predicate = command.Predicate;
    }
}
