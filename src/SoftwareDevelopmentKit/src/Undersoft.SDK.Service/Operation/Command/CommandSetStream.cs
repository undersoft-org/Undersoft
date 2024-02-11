using MediatR;

namespace Undersoft.SDK.Service.Operation.Command;

using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Operation;

public class CommandSetStream<TDto>
    : CommandSet<TDto>,
        IStreamRequest<Command<TDto>>,
        ICommandSet<TDto> where TDto : class, IOrigin, IInnerProxy
{
    protected CommandSetStream() : base() { }

    protected CommandSetStream(OperationType commandMode) : base(commandMode) { }

    protected CommandSetStream(
        OperationType commandMode,
        EventPublishMode publishPattern,
        Command<TDto>[] DtoCommands
    ) : base(commandMode, publishPattern, DtoCommands) { }
}
