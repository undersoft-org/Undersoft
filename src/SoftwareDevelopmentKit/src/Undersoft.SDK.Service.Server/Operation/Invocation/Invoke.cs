using Undersoft.SDK.Service.Server.Operation.Command;

namespace Undersoft.SDK.Service.Server.Operation.Invocation;

using Undersoft.SDK.Service.Data;
using Undersoft.SDK.Service.Infrastructure.Store;

public class Invoke<TStore, TService, TDto> : Invocation<TDto>
    where TDto : class
    where TService : class
    where TStore : IDataServerStore
{
    public Invoke() : base() { }

    public Invoke(string method) : base(CommandMode.Invoke, typeof(TService), method) { }

    public Invoke(object argument, string method)
    : base(argument, CommandMode.Invoke, typeof(TService), method) { }

    public Invoke(string method, Arguments arguments)
     : base(CommandMode.Invoke, typeof(TService), method, arguments) { }

    public Invoke(string method, params object[] arguments)
    : base(CommandMode.Invoke, typeof(TService), method, arguments) { }

}
 