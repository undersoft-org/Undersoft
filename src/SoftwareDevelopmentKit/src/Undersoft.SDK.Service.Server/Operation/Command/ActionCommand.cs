﻿using MediatR;
using System.Text.Json.Serialization;

namespace Undersoft.SDK.Service.Server.Operation.Command;

using Undersoft.SDK.Service.Data;
using Uniques;

public class ActionCommand<TDto, TKind> : ActionCommandBase, IRequest<ActionCommand<TDto, TKind>> where TDto : class where TKind : Enum
{
    private long id;

    private Uscn code =  new Uscn(Unique.NewId);

    [JsonIgnore]
    public override TDto Data => base.Data as TDto;

    protected ActionCommand() { }

    protected ActionCommand(CommandMode commandMode, TDto dataObject)
    {
        CommandMode = commandMode;
        base.Data = dataObject;
    }

    protected ActionCommand(CommandMode commandMode, TKind kind, TDto dataObject)
        : base(dataObject, commandMode, kind) { }

    protected ActionCommand(
        CommandMode commandMode,
        TKind kind,
        TDto dataObject,
        params object[] keys
    ) : base(dataObject, commandMode, kind, keys) { }

    protected ActionCommand(CommandMode commandMode, TKind publishMode, params object[] keys)
        : base(commandMode, publishMode, keys) { }

    public byte[] GetBytes()
    {
        return Data.GetBytes();
    }

    public bool Equals(IUnique other)
    {
        return Data.Equals(other);
    }

    public int CompareTo(IUnique other)
    {
        return code.CompareTo(other);
    }

    public override long Id
    {
        get => code.Id;
        set => code.Id = value;
    }

    public long TypeId
    {
        get => code.TypeId;
        set => code.TypeId = value;
    }
}
