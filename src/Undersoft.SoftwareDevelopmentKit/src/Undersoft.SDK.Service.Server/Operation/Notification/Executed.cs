namespace Undersoft.SDK.Service.Server.Operation.Notification;

using Command;

using Undersoft.SDK;
using Undersoft.SDK.Service.Infrastructure.Store;

public class Executed<TStore, TType, TDto, TKind> : ActionNotification<ActionCommand<TDto, TKind>>
    where TType : class
    where TDto : class, IOrigin
    where TKind : Enum
    where TStore : IDataServiceStore
{
    public Executed(Execute<TStore, TType, TDto, TKind> command) : base(command)
    {
    }
}
