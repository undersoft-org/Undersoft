namespace Undersoft.SDK.Invoking
{
    using System.Reflection;
    using System.Runtime.InteropServices;
    using Undersoft.SDK.Series;
    using Undersoft.SDK.Uniques;

    public class Arguments : Listing<Argument>
    {
        public Arguments() : base() { }
        public Arguments(Argument argument) : base(new[] { argument }) { }
        public Arguments(ParameterInfo[] parameters) : base(parameters.ForEach(p => new Argument(p))) { }
        public Arguments(Dictionary<string, object> dictionary) : base(dictionary.ForEach(p => new Argument(p.Key, p.Value))) { }

        public object[] ValueArray => this.OrderBy(a => a.Position).Select(a => a.Value).ToArray();

        public Type[] TypeArray => this.OrderBy(a => a.Position).Select(a => a.Type).ToArray();
    }
}
