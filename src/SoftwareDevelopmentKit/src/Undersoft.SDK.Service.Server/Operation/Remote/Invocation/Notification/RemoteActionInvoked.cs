﻿using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Undersoft.SDK.Service.Server.Operation.Remote.Invocation.Notification;

using Command;
using Undersoft.SDK;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SDK.Service.Server.Operation.Invocation;
using Undersoft.SDK.Service.Server.Operation.Remote.Invocation;

public class RemoteActionInvoked<TStore, TService, TModel> : RemoteInvokeNotification<Invocation<TModel>>
    where TModel : class, IOrigin
    where TService : class
    where TStore : IDataServiceStore
{
    public RemoteActionInvoked(RemoteAction<TStore, TService, TModel> command) : base(command)
    {
    }
}
