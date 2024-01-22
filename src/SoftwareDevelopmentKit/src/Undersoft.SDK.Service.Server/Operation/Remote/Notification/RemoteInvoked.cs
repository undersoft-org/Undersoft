using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Undersoft.SDK.Service.Server.Operation.Remote.Notification;

using Command;



using Undersoft.SDK.Service.Server.Operation.Notification;
using Undersoft.SDK;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Operation.Invocation;

public class RemoteInvoked<TStore, TService, TModel> : RemoteActionNotification<Invocation<TModel>>
    where TModel : class, IOrigin
    where TService : class    
    where TStore : IDataServiceStore
{
    public RemoteInvoked(RemoteInvoke<TStore, TService, TModel> command) : base(command)
    {
    }
}
