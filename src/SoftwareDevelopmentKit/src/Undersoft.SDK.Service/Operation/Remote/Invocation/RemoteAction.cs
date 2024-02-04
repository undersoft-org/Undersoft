using Undersoft.SDK.Service.Operation.Command;
using Undersoft.SDK.Service.Operation.Invocation;

namespace Undersoft.SDK.Service.Operation.Remote.Invocation;

public class RemoteAction<TStore, TService, TModel> : Invocation<TModel>
    where TService : class
    where TModel : class
    where TStore : IDataServiceStore
{
    public RemoteAction() : base() { }

    public RemoteAction(string method, object argument)
        : base(CommandMode.Action, typeof(TService), method, argument) { }

    public RemoteAction(string method, Arguments arguments)
        : base(CommandMode.Action, typeof(TService), method, arguments) { }

    public RemoteAction(string method, object[] arguments)
        : base(CommandMode.Action, typeof(TService), method, arguments) { }

    public RemoteAction(string method, byte[] arguments)
        : base(CommandMode.Action, typeof(TService), method, arguments) { }
}
