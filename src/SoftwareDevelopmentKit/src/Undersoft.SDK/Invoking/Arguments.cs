namespace Undersoft.SDK.Invoking
{
    using System.Reflection;
    using System.Runtime.InteropServices;
    using Undersoft.SDK.Series;
    using Undersoft.SDK.Uniques;

    public class Arguments : Listing<Argument>
    {
        public Arguments() : base() { }
        public Arguments(ParameterInfo[] parameters) : base(parameters.ForEach(p => new Argument(p))) { }
    }
}
