using System.Linq.Expressions;
using System.Text.Json.Serialization;
using Undersoft.SDK.Service.Application.Operation.Command;
using Undersoft.SDK.Service.Data;

namespace Undersoft.SDK.Service.Application.Operation.Remote.Command;

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
