﻿using FluentValidation.Results;
using MediatR;
using Undersoft.SDK.Service.Application.Operation.Command;


namespace Undersoft.SDK.Service.Application.Operation.Remote.Command;

public class RemoteCommandSet<TModel>
    : Registry<RemoteCommand<TModel>>,
        IRequest<RemoteCommandSet<TModel>>,
        IRemoteCommandSet<TModel> where TModel : class, IDataObject
{
    public CommandMode CommandMode { get; set; }

    public EventPublishMode PublishMode { get; set; }

    protected RemoteCommandSet() : base(true) { }

    protected RemoteCommandSet(CommandMode commandMode) : base()
    {
        CommandMode = commandMode;
    }

    protected RemoteCommandSet(
        CommandMode commandMode,
        EventPublishMode publishPattern,
        RemoteCommand<TModel>[] DtoCommands
    ) : base(DtoCommands)
    {
        CommandMode = commandMode;
        PublishMode = publishPattern;
    }

    public IEnumerable<RemoteCommand<TModel>> Commands
    {
        get => AsValues();
    }

    public ValidationResult Result { get; set; } = new ValidationResult();

    public object Input => Commands.Select(c => c.Model);

    public object Output => Commands.ForEach(c => c.Result.IsValid ? c.Id as object : c.Result);

    IEnumerable<IRemoteCommand> IRemoteCommandSet.Commands
    {
        get => this.Cast<IRemoteCommand>();
    }
}
