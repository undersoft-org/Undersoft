﻿using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Undersoft.SDK.Service.Server.Operation.Remote.Command.Notification;

using Command;

using Undersoft.SDK.Service.Infrastructure.Store;

public class RemoteUpdatedSet<TStore, TDto, TModel> : RemoteNotificationSet<RemoteCommand<TModel>>
    where TDto : class, IOrigin, IInnerProxy
    where TModel : class, IOrigin, IInnerProxy
    where TStore : IDataServiceStore
{
    public RemoteUpdatedSet(RemoteUpdateSet<TStore, TDto, TModel> commands)
        : base(
            commands.PublishMode,
            commands
                .ForOnly(
                    c => c.Contract != null,
                    c => new RemoteUpdated<TStore, TDto, TModel>((RemoteUpdate<TStore, TDto, TModel>)c)
                )
                .ToArray()
        )
    {
        Predicate = commands.Predicate;
        Conditions = commands.Conditions;
    }

    [JsonIgnore]
    public Func<TModel, Expression<Func<TDto, bool>>>[] Conditions { get; }

    [JsonIgnore]
    public Func<TModel, Expression<Func<TDto, bool>>> Predicate { get; }
}
