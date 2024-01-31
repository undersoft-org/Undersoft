using System.Linq.Expressions;
using System.Text.Json.Serialization;
using Undersoft.SDK.Service.Server.Operation.Command;
using Microsoft.AspNetCore.OData.Formatter;
using Undersoft.SDK.Service.Server.Operation.Invocation;
using Undersoft.SDK.Service.Data.Store;

namespace Undersoft.SDK.Service.Server.Operation.Remote.Invocation;

public class RemoteAction<TStore, TService, TModel> : Invocation<TModel>
    where TService : class
    where TModel : class
    where TStore : IDataServiceStore
{
    public RemoteAction() : base() { }

    public RemoteAction(string method, object argument)
        : base(CommandMode.Invoke, typeof(TService), method, argument) { }

    public RemoteAction(string method, Arguments arguments)
        : base(CommandMode.Invoke, typeof(TService), method, arguments) { }

    public RemoteAction(string method, object[] arguments)
        : base(CommandMode.Invoke, typeof(TService), method, arguments) { }

    public RemoteAction(string method, byte[] arguments)
        : base(CommandMode.Invoke, typeof(TService), method, arguments) { }
}
