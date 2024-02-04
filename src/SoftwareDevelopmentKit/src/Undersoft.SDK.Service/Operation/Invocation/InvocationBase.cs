using FluentValidation.Results;
using System.Text.Json.Serialization;
using Undersoft.SDK.Service.Operation.Command;

namespace Undersoft.SDK.Service.Operation.Invocation;

public abstract class InvocationBase : IInvocation
{
    public virtual long Id { get; set; }

    public Arguments Arguments { get; set; }

    public virtual object Return { get; set; }

    public Delegate Processings { get; set; }

    [JsonIgnore]
    public virtual object Response { get; set; }

    [JsonIgnore]
    public ValidationResult Result { get; set; }

    public string ErrorMessages => Result.ToString();

    public CommandMode CommandMode { get; set; }

    public virtual object Input => Arguments;

    public virtual object Output => IsValid ? Response : ErrorMessages;

    public bool IsValid => Result.IsValid;

    protected InvocationBase()
    {
        Result = new ValidationResult();
    }

    protected InvocationBase(CommandMode commandMode) : this()
    {
        CommandMode = commandMode;
    }

    protected InvocationBase(CommandMode commandMode, Type serviceType, string method, object argument)
        : this(commandMode)
    {
        Arguments = new Arguments(method, argument, serviceType.FullName);
        Arguments.TargetType = serviceType;
    }

    protected InvocationBase(CommandMode commandMode, Type serviceType, string method, Arguments arguments)
        : this(commandMode)
    {
        Arguments = arguments;
        Arguments.ForEach(a => a.TargetName = serviceType.FullName);
        Arguments.TargetType = serviceType;
    }

    protected InvocationBase(CommandMode commandMode, Type serviceType, string method, object[] arguments)
       : this(commandMode)
    {
        var args = new Arguments(method, serviceType.FullName);
        arguments.ForEach(a => args.New(a.GetType().Name, a, method, serviceType.FullName));
        args.TargetType = serviceType;
        Arguments = args;
    }

    protected InvocationBase(CommandMode commandMode, Type serviceType, string method, byte[] binaries)
       : this(commandMode)
    {
        Arguments = new Arguments(method, binaries);
        Arguments.TargetType = serviceType;
    }

    public void SetArguments(Arguments arguments) => Arguments = arguments;
}
