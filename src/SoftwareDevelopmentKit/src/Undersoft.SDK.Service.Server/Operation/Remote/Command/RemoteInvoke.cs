using System.Linq.Expressions;
using System.Text.Json.Serialization;
using Undersoft.SDK.Service.Server.Operation.Command;
using Undersoft.SDK.Service.Data;
using Undersoft.SDK.Service.Infrastructure.Store;
using Microsoft.AspNetCore.OData.Formatter;

namespace Undersoft.SDK.Service.Server.Operation.Invocation;

public class RemoteInvoke<TStore, TService, TModel> : Invocation<TModel>
    where TService : class
    where TModel : class
    where TStore : IDataServiceStore
{
    public RemoteInvoke() : base() { }

    public RemoteInvoke(string method) : base(CommandMode.Invoke, typeof(TService), method) { }

    public RemoteInvoke(object argument, string method)
    : base(argument, CommandMode.Invoke, typeof(TService), method) { }

    public RemoteInvoke(string method, Arguments arguments)
     : base(CommandMode.Invoke, typeof(TService), method, arguments) { }

    public RemoteInvoke(string method, params object[] arguments)
    : base(CommandMode.Invoke, typeof(TService), method, arguments) { }
}
