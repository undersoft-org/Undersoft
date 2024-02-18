using FluentValidation.Results;
using MediatR;

namespace Undersoft.SDK.Service.Operation.Command;

using Series;
using Undersoft.SDK;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Service.Data.Event;

public class CommandSet<TDto>
    : Listing<Command<TDto>>,
        IRequest<CommandSet<TDto>>,
        ICommandSet<TDto> where TDto : class, IOrigin, IInnerProxy
{
    public OperationType CommandMode { get; set; }

    public EventPublishMode PublishMode { get; set; }

    protected CommandSet() : base() { }

    protected CommandSet(OperationType commandMode) : base()
    {
        CommandMode = commandMode;
    }

    protected CommandSet(
        OperationType commandMode,
        EventPublishMode publishPattern,
        Command<TDto>[] DtoCommands
    ) : base(DtoCommands)
    {
        CommandMode = commandMode;
        PublishMode = publishPattern;
    }

    public IEnumerable<Command<TDto>> Commands
    {
        get => AsValues();
    }

    public ValidationResult Result { get; set; } = new ValidationResult();

    public object Input => Commands.Select(c => c.Contract);

    public object Output => Commands.ForEach(c => c.Result.IsValid ? c.Id as object : c.Result);

    public Delegate Processings { get; set; }

    IEnumerable<ICommand> ICommandSet.Commands
    {
        get => this.Cast<ICommand>();
    }
}
