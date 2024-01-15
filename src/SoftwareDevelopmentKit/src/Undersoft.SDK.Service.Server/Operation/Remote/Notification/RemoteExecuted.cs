using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Undersoft.SDK.Service.Server.Operation.Remote.Notification;

using Command;



using Undersoft.SDK.Service.Server.Operation.Notification;
using Undersoft.SDK.Service.Server.Operation.Command;
using Undersoft.SDK;
using Undersoft.SDK.Service.Infrastructure.Store;

public class RemoteExecuted<TStore, TDto, TModel, TKind> : RemoteActionNotification<ActionCommand<TModel, TKind>>
    where TDto : class, IOrigin
    where TModel : class, IOrigin
    where TKind : Enum
    where TStore : IDataServiceStore
{
    public RemoteExecuted(RemoteExecute<TStore, TDto, TModel, TKind> command) : base(command)
    {
    }
}
