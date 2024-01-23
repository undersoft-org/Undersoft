﻿using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Undersoft.SDK.Service.Server.Operation.Command.Notification;

using Command;


using Undersoft.SDK.Service.Infrastructure.Store;

public class Changed<TStore, TEntity, TDto> : Notification<Command<TDto>>
    where TDto : class, IDataObject
    where TEntity : class, IDataObject
    where TStore : IDataServerStore
{
    public Changed(Command<TDto> command) : base(command) { }

    public Changed(Change<TStore, TEntity, TDto> command) : base(command)
    {
        Predicate = command.Predicate;
    }

    [JsonIgnore]
    public Func<TDto, Expression<Func<TEntity, bool>>> Predicate { get; }
}
