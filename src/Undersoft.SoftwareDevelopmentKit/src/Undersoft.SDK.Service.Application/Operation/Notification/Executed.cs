namespace Undersoft.SDK.Service.Application.Operation.Notification;

using Command;
using SDK.Service.Data.Store;
using Undersoft.SDK;

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
