using System.Linq.Expressions;
using System.Text.Json.Serialization;
using Undersoft.SDK.Service.Server.Operation.Command;
using Undersoft.SDK.Service.Data;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SDK.Service.Server.Operation.Remote.Command;

public class RemoteExecute<TStore, TDto, TModel, TKind> : ActionCommand<TModel, TKind>
    where TModel : class, IOrigin
    where TDto : class, IOrigin
    where TKind : Enum
    where TStore : IDataServiceStore
{
    public RemoteExecute(TKind kind, TModel input, CommandMode mode = CommandMode.Action)
        : base(mode, kind, input)
    {
        input.AutoId();
    }
}
