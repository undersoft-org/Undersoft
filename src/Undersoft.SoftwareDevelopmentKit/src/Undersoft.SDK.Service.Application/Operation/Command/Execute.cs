namespace Undersoft.SDK.Service.Application.Operation.Command;
using SDK.Service.Data.Store;
using Undersoft.SDK.Service.Data;

public class Execute<TStore, TType, TInput, TKind> : ActionCommand<TInput, TKind>
    where TInput : class
    where TType : class
    where TKind : Enum
    where TStore : IDataServiceStore
{
    public Execute(TKind publishPattern) : base(CommandMode.Invoke, publishPattern) { }

    public Execute(TKind publishPattern, TInput input)
        : base(CommandMode.Invoke, publishPattern, input)  { }
}
