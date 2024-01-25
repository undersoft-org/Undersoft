﻿namespace Undersoft.SDK.Service.Server.Operation.Invocation.Notification;

using Command;

using Undersoft.SDK;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Operation.Invocation;

public class SetupInvoked<TStore, TType, TDto> : InvokeNotification<Invocation<TDto>>
    where TType : class
    where TDto : class, IOrigin
    where TStore : IDataServerStore
{
    public SetupInvoked(Setup<TStore, TType, TDto> command) : base(command)
    {
    }
}
