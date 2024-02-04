﻿using MediatR;
using System.Text.Json;

namespace Undersoft.SDK.Service.Operation.Command.Notification;

using Command;
using Logging;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Operation.Command;
using Uniques;

public abstract class Notification<TCommand> : Event, INotification where TCommand : CommandBase
{
    public TCommand Command { get; }

    public Notification() : base() { }

    protected Notification(TCommand command) : base()
    {
        var aggregateTypeFullName = command.Entity.GetDataFullName();
        var eventTypeFullName = GetType().FullName;

        Command = command;
        Id = Unique.NewId;
        EntityId = command.Id;
        EntityTypeName = aggregateTypeFullName;
        TypeName = eventTypeFullName;
        var entity = (Entity)command.Entity;
        OriginId = entity.OriginId;
        Modifier = entity.Modifier;
        Modified = entity.Modified;
        Creator = entity.Creator;
        Created = entity.Created;
        PublishStatus = EventPublishStatus.Ready;
        PublishTime = Log.Clock;

        Data = JsonSerializer.SerializeToUtf8Bytes((CommandBase)command);
    }

    public Event GetEvent()
    {
        return new Event()
        {
            Id = Id,
            TypeId = TypeId,
            OriginId = OriginId,
            TypeName = TypeName,
            Modifier = Modifier,
            Data = Data,
            Version = Version,
            EntityId = EntityId,
            EntityTypeName = EntityTypeName,
            Modified = Modified,
            Creator = Creator,
            Created = Created,
            PublishStatus = PublishStatus,
            PublishTime = PublishTime
        };
    }
}