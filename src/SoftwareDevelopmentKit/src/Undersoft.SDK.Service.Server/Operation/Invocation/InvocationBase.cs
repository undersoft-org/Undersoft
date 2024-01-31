using FluentValidation.Results;
using ServiceStack;
using System.Text.Json;
using System.Text.Json.Serialization;
using Undersoft.SDK.Service.Server.Operation.Command;

namespace Undersoft.SDK.Service.Server.Operation.Invocation;

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
        var methodInfo = serviceType.GetMethod(method, new Type[] { argument.GetType() });
        if (methodInfo != null)
        {
            Arguments = new Arguments(methodInfo.Name, methodInfo.GetParameters(), serviceType.FullName, serviceType);
            Arguments[0].Value = argument;
        }
    }

    protected InvocationBase(CommandMode commandMode, Type serviceType, Arguments arguments)
        : this(commandMode)
    {
        var methodInfo = serviceType.GetMethod(arguments.MethodName, arguments.TypeArray);
        if (methodInfo != null)
        {
            Arguments = new Arguments(methodInfo.Name, methodInfo.GetParameters(), serviceType.FullName, serviceType);
            Arguments.ForEach(a => 
            { 
                if (arguments.ContainsKey(a.Name))
                    a.Value = a.Value.GetType().IsAssignableTo(typeof(JsonElement)) 
                    ? ((JsonElement)arguments[a.Name].Value).Deserialize(a.Type) 
                    : arguments[a.Name].Value; 
            });
        }
    }

    protected InvocationBase(CommandMode commandMode, Type serviceType, string method, object[] arguments)
       : this(commandMode)
    {
        var methodInfo = serviceType.GetMethod(method, arguments.Select(a => a.GetType()).ToArray());
        if (methodInfo != null)
        {
            Arguments = new Arguments(methodInfo.Name, methodInfo.GetParameters(), serviceType.FullName, serviceType);
            Arguments.ForEach((a, x) =>{ if(a.Type == arguments[x].GetType()) a.Value = arguments[x]; } );
        }
    }

    protected InvocationBase(CommandMode commandMode, Type serviceType, string method, byte[] binaries)
       : this(commandMode)
    {
            Arguments = new Arguments(method, binaries);                   
    }

    public void SetArguments(Arguments arguments) => Arguments = arguments;
}
