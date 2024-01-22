﻿using MediatR;
using System.Text.Json.Serialization;

namespace Undersoft.SDK.Service.Server.Operation.Invocation;

using IdentityModel.Client;
using Undersoft.SDK.Service.Data;
using Undersoft.SDK.Service.Server.Operation.Command;
using Uniques;

public class Invocation<TDto> : InvocationBase, IRequest<Invocation<TDto>> where TDto : class
{
    private long id;
    private string method;

    private Type serviceType;

    private Uscn code = new Uscn(Unique.NewId);

    public new TDto Return {  get; set; }

    protected Invocation() { }

    protected Invocation(object argument, CommandMode commandMode, Type serviceType, string method)
        : base(argument, commandMode, serviceType, method) { }

    protected Invocation(CommandMode commandMode, Type serviceType, string method) : base(commandMode, serviceType, method) { }

    protected Invocation(CommandMode commandMode, Type serviceType, string method, Arguments arguemnts)
        : base(commandMode, serviceType, method, arguemnts) { }

    protected Invocation(CommandMode commandMode, Type serviceType, string method, params object[] arguments)
       : base(commandMode, serviceType, method, arguments) { }

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
