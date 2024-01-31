namespace Undersoft.SDK.Invoking
{
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;
    using Undersoft.SDK.Series;

    public class Arguments : Listing<Argument>
    {
        public Arguments() : base() { }

        public Arguments(string methodName, string targetName = null, Type targetType = null) : base()
        {
            TargetName = targetName;
            TargetType = targetType;
            MethodName = methodName;
        }

        public Arguments(string methodName, object argValue, string targetName = null, Type targetType = null)
           : this(methodName, new Argument(argValue), targetName, targetType) { }
        
        public Arguments(string methodName, string argName, object argValue, string targetName = null, Type targetType = null)
            : this(methodName, new Argument(argName, argValue), targetName, targetType) { }
        
        public Arguments(string methodName, Argument argument, string targetName, Type targetType)
            : this(methodName, targetName, targetType)
        {
            this.Add(argument);
        }
        
        public Arguments(string methodName, ParameterInfo[] parameters, string targetName = null, Type targetType = null)
            : this(methodName, targetName, targetType)
        {
            this.Add(parameters.DoEach(p => new Argument(p)));
        }

        public Arguments(            
            string methodName,
            Dictionary<string, object> dictionary,
            string targetName
        ) : this(methodName, targetName)
        {
            this.Add(dictionary.ForEach(p => new Argument(p.Key, p.Value)));
        }

        [JsonIgnore]
        [IgnoreDataMember]
        public object[] ValueArray =>
            this.AsItems()
                .OrderBy(a => a.Value.Position = a.Value.Position < 0 ? a.Index : a.Value.Position)
                .Select(a => a.Value.Value)
                .ToArray();

        [JsonIgnore]
        [IgnoreDataMember]
        public Type[] TypeArray => this.OrderBy(a => a.Position).Select(a => a.Type).ToArray();

        [JsonIgnore]
        [IgnoreDataMember]
        public Type TargetType { get; set; }

        public string TargetName { get; set; }

        public string MethodName { get; set; }

        public Argument New(string name, object value)
        {
            return this.Put(new Argument(name, value)).Value;
        }

        public override ISeriesItem<Argument> New(object value)
        {
            return this.Put(new Argument(value.GetType().Name, value));
        }
    }
}
