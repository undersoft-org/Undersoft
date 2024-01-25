using System.Linq.Expressions;
using System.Text.Json.Serialization;
using Undersoft.SDK.Service.Server.Operation.Command;
using Undersoft.SDK.Service.Data;
using Undersoft.SDK.Service.Infrastructure.Store;
using Microsoft.AspNetCore.OData.Formatter;
using Undersoft.SDK.Service.Server.Operation.Invocation;

namespace Undersoft.SDK.Service.Server.Operation.Remote.Invocation;

public class RemoteSetup<TStore, TService, TModel> : Invocation<TModel>
    where TService : class
    where TModel : class
    where TStore : IDataServiceStore
{
    public RemoteSetup() : base() { }

    public RemoteSetup(string method) : base(CommandMode.Invoke, typeof(TService), method) { }

    public RemoteSetup(string method, Arguments arguments)
     : base(CommandMode.Invoke, typeof(TService), method, arguments) { }

    public RemoteSetup(string method, params object[] arguments)
    : base(CommandMode.Invoke, typeof(TService), method, arguments) { }
}
