using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Undersoft.SDK.Service.Server.Operation.Notification;

using Command;
using Undersoft.SDK.Service.Server.Operation.Remote.Command;
using Undersoft.SDK.Service.Server.Operation.Remote.Notification;



using Undersoft.SDK.Service.Infrastructure.Store;

public class RemoteUpsertedSet<TStore, TDto, TModel> : RemoteNotificationSet<RemoteCommand<TModel>>
    where TDto : class, IDataObject
    where TModel : class, IDataObject
    where TStore : IDataServiceStore
{
    [JsonIgnore]
    public Func<TDto, Expression<Func<TDto, bool>>> Predicate { get; }

    [JsonIgnore]
    public Func<TDto, Expression<Func<TDto, bool>>>[] Conditions { get; }

    public RemoteUpsertedSet(RemoteUpsertSet<TStore, TDto, TModel> commands)
        : base(
            commands.PublishMode,
            commands
                .ForOnly(
                    c => c.Contract != null,
                    c => new RemoteUpserted<TStore, TDto, TModel>((RemoteUpsert<TStore, TDto, TModel>)c)
                )
                .ToArray()
        )
    {
        Conditions = commands.Conditions;
        Predicate = commands.Predicate;
    }
}
