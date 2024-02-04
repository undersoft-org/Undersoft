using Undersoft.SDK.Service.Operation.Command;
using Undersoft.SDK.Service.Operation.Invocation;

namespace Undersoft.SDK.Service.Operation.Remote.Invocation;

public class RemoteSetup<TStore, TService, TModel> : Invocation<TModel>
    where TService : class
    where TModel : class
    where TStore : IDataServiceStore
{
    public RemoteSetup() : base() { }

    public RemoteSetup(string method, object argument) : base(CommandMode.Setup, typeof(TService), method, argument) { }

    public RemoteSetup(string method, Arguments arguments)
     : base(CommandMode.Setup, typeof(TService), method, arguments) { }

    public RemoteSetup(string method, params object[] arguments)
    : base(CommandMode.Setup, typeof(TService), method, arguments) { }

    public RemoteSetup(string method, params byte[] arguments)
    : base(CommandMode.Setup, typeof(TService), method, arguments) { }
}