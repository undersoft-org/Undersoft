﻿namespace Undersoft.SDK.Invoking
{
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;
    using Undersoft.SDK.Series;

    [DataContract]
    [Serializable]
    public class Arguments : Listing<Argument>
    {
        public Arguments() : base() { }

        public Arguments(string methodName, string targetName = null, Type targetType = null) : base()
        {
            TargetType = targetType;            
        }

        public Arguments(string methodName, object argValue, string targetName = null, Type targetType = null)
           : this(methodName, new Argument(argValue, methodName, targetName), targetName, targetType) { }
        
        public Arguments(string methodName, string argName, object argValue, string targetName = null, Type targetType = null)
            : this(methodName, new Argument(argName, argValue, methodName, targetName), targetName, targetType) { }
        
        public Arguments(string methodName, Argument argument, string targetName, Type targetType)
            : this(methodName, targetName, targetType)
        {
            argument.MethodName = methodName;
            argument.TargetName = targetName;   
            this.Add(argument);
        }
        
        public Arguments(string methodName, ParameterInfo[] parameters, string targetName = null, Type targetType = null)
            : this(methodName, targetName, targetType)
        {
            this.Add(parameters.DoEach(p => new Argument(p, methodName, targetName)));
        }

        public Arguments(            
            string methodName,
            Dictionary<string, object> dictionary,
            string targetName
        ) : this(methodName, targetName)
        {
            this.Add(dictionary.ForEach(p => new Argument(p.Key, p.Value, methodName, targetName)));
        }

        [JsonIgnore]
        [IgnoreDataMember]
        public object[] ValueArray =>
            this.AsValues().ForEach(i => i.Deserialize()).ToArray();                

        [JsonIgnore]
        [IgnoreDataMember]
        public Type[] TypeArray => this.OrderBy(a => a.Position).Select(a => Type.GetType(a.ArgumentTypeName)).ToArray();

        [JsonIgnore]
        [IgnoreDataMember]
        public Type TargetType { get; set; }

        public string TargetName => this.FirstOrDefault()?.TargetName;

        public string MethodName => this.FirstOrDefault()?.MethodName;

        public Argument New(string name, object value, string method, string target)
        {
            return this.Put(new Argument(name, value, method, target)).Value;
        }

        public ISeries<object> Deserialize()
        {
            return this.ForEach(i => i.Deserialize()).ToListing();
        }

        public ISeriesItem<Argument> New(object value, string method, string target = null)
        {
            return this.Put(new Argument(value.GetType().Name, value, method, target));
        }
    }
}
