﻿using MediatR;
using System.Text.Json;

namespace Undersoft.SDK.Service.Server.Operation.Notification;

using Command;
using Logging;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Server.Operation.Invocation;
using Uniques;

public abstract class RemoteActionNotification<TCommand> : Event, INotification where TCommand : InvocationBase
{
    public TCommand Command { get; }

    protected RemoteActionNotification(TCommand command)
    {
        var aggregateTypeFullName = command.Response.GetDataFullName();
        var eventTypeFullName = GetType().FullName;

        Command = command;
        Id = (long)Unique.NewId;
        AggregateId = command.Id;
        AggregateType = aggregateTypeFullName;
        EventType = eventTypeFullName;
        var response = command.Response;
        PublishStatus = EventPublishStatus.Ready;
        PublishTime = Log.Clock;

        EventData = JsonSerializer.SerializeToUtf8Bytes((InvocationBase)command);
    }
}
