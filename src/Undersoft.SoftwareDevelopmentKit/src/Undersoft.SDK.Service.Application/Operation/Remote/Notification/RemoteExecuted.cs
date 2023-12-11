using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Undersoft.SDK.Service.Application.Operation.Remote.Notification;

using Command;


using SDK.Service.Data.Store;
using Undersoft.SDK.Service.Application.Operation.Notification;
using Undersoft.SDK.Service.Application.Operation.Command;
using Undersoft.SDK;

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
