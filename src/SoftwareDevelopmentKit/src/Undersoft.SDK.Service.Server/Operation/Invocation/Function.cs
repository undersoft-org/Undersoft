using Undersoft.SDK.Service.Server.Operation.Command;

namespace Undersoft.SDK.Service.Server.Operation.Invocation;

using Undersoft.SDK.Service.Data;
using Undersoft.SDK.Service.Infrastructure.Store;

public class Function<TStore, TService, TDto> : Invocation<TDto>
    where TDto : class
    where TService : class
    where TStore : IDataServerStore
{
    public Function() : base() { }

    public Function(string method) : base(CommandMode.Invoke, typeof(TService), method) { }

    public Function(string method, Arguments arguments)
     : base(CommandMode.Invoke, typeof(TService), method, arguments) { }

    public Function(string method, params object[] arguments)
    : base(CommandMode.Invoke, typeof(TService), method, arguments) { }

}
 