﻿using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Undersoft.SDK.Service.Server.Operation.Command.Notification;
using Command;


using Undersoft.SDK.Service.Infrastructure.Store;

public class Deleted<TStore, TEntity, TDto> : Notification<Command<TDto>>
    where TDto : class, IOrigin, IInnerProxy
    where TEntity : class, IOrigin, IInnerProxy
    where TStore : IDataServerStore
{
    [JsonIgnore]
    public Func<TEntity, Expression<Func<TEntity, bool>>> Predicate { get; }

    public Deleted(Delete<TStore, TEntity, TDto> command) : base(command)
    {
        Predicate = command.Predicate;
    }
}
