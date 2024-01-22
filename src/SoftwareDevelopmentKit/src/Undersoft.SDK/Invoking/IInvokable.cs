using System.Reflection;
using System.Threading.Tasks;

namespace Undersoft.SDK.Invoking
{
    using Undersoft.SDK.Instant;
    using Undersoft.SDK.Series;
    using Uniques;

    public interface IInvokable : IIdentifiable, IValueArray, IInstant
    {
        string Name { get; set; }

        string QualifiedName { get; set; }

        string MethodName { get; set; }

        AssemblyName AssemblyName { get; }       

        string TypeName { get; set; }

        Type Type { get; }

        MethodInfo Info { get; }

        Arguments Arguments { get; set; }

        Type ReturnType { get; }
    }
}
