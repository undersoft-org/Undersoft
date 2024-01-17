﻿using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Undersoft.SDK.Service.Server.Operation.Notification;

using Command;
using Undersoft.SDK.Service.Server.Operation.Remote.Command;
using Undersoft.SDK.Service.Server.Operation.Remote.Notification;

using Undersoft.SDK.Service.Data.Entity;


using Undersoft.SDK.Service.Infrastructure.Store;

public class RemoteUpserted<TStore, TDto, TModel> : RemoteNotification<RemoteCommand<TModel>>
    where TDto : class, IDataObject
    where TModel : class, IDataObject
    where TStore : IDataServiceStore
{
    [JsonIgnore]
    public Func<TDto, Expression<Func<TDto, bool>>> Predicate { get; }

    [JsonIgnore]
    public Func<TDto, Expression<Func<TDto, bool>>>[] Conditions { get; }

    public RemoteUpserted(RemoteUpsert<TStore, TDto, TModel> command) : base(command)
    {
        Conditions = command.Conditions;
        Predicate = command.Predicate;
    }
}