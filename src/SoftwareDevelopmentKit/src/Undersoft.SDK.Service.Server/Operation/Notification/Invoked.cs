namespace Undersoft.SDK.Service.Server.Operation.Notification;

using Command;

using Undersoft.SDK;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Operation.Invocation;

public class Invoked<TStore, TType, TDto> : ActionNotification<Invocation<TDto>>
    where TType : class
    where TDto : class, IOrigin
    where TStore : IDataServerStore
{
    public Invoked(Invoke<TStore, TType, TDto> command) : base(command)
    {
    }
}
