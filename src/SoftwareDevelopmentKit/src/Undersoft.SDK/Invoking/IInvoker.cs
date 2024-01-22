using System.Reflection;
using System.Threading.Tasks;

namespace Undersoft.SDK.Invoking
{
    using Undersoft.SDK.Instant;
    using Uniques;

    public interface IInvoker : IInvokable
    {
        object TargetObject { get; set; }

        ParameterInfo[] Parameters { get; set; }

        InvokerDelegate MethodInvoker { get; }

        Delegate Method { get; }

        Task Publish(params object[] parameters);
        Task Publish(bool firstAsTarget, object target, params object[] parameters);

        object Invoke(params object[] parameters);
        object Invoke(bool firstAsTarget, object target, params object[] parameters);

        Task<object> InvokeAsync(params object[] parameters);
        Task<object> InvokeAsync(bool firstAsTarget, object target, params object[] parameters);

        Task<T> InvokeAsync<T>(params object[] parameters);
        Task<T> InvokeAsync<T>(bool firstAsTarget, object target, params object[] parameters);
    }
}
