using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Undersoft.SDK.Service.Server.Operation.Notification;

using Command;


using Undersoft.SDK.Service.Infrastructure.Store;

public class ChangedSet<TStore, TEntity, TDto> : NotificationSet<Command<TDto>>
    where TDto : class, IDataObject
    where TEntity : class, IDataObject
    where TStore : IDatabaseStore
{
    [JsonIgnore]
    public Func<TDto, Expression<Func<TEntity, bool>>> Predicate { get; }

    public ChangedSet(ChangeSet<TStore, TEntity, TDto> commands)
        : base(
            commands.PublishMode,
            commands
                .ForOnly(
                    c => c.Entity != null,
                    c => new Changed<TStore, TEntity, TDto>((Change<TStore, TEntity, TDto>)c)
                )
                .ToArray()
        )
    {
        Predicate = commands.Predicate;
    }
}
