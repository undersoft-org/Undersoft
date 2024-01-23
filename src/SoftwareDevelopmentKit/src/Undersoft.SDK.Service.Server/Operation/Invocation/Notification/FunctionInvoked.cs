namespace Undersoft.SDK.Service.Server.Operation.Invocation.Notification;

using Command;

using Undersoft.SDK;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Operation.Invocation;

public class FunctionInvoked<TStore, TType, TDto> : InvokeNotification<Invocation<TDto>>
    where TType : class
    where TDto : class, IOrigin
    where TStore : IDataServerStore
{
    public FunctionInvoked(Function<TStore, TType, TDto> command) : base(command)
    {
    }
}
